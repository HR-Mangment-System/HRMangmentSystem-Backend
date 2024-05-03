using AutoMapper;
using Azure;
using HRMangmentSystem.API.DTOS.AnnualHolidaysDTO;
using HRMangmentSystem.API.DTOS.SettingsDto;
using HRMangmentSystem.API.ResponseBase;
using HRMangmentSystem.BusinessLayer.IRepository;
using HRMangmentSystem.BusinessLayer.Repository;
using HRMangmentSystem.DataAccessLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRMangmentSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnnualHolidaysController : ControllerBase
    {
        private readonly IAnnualHolidaysRepository _annualHolidaysRepository;
        private readonly IMapper _mapper;
        private readonly ResponseHandler _responseHandler;
        public AnnualHolidaysController(IAnnualHolidaysRepository annualHolidaysRepository, IMapper mapper, ResponseHandler responseHandler)
        {
            _annualHolidaysRepository = annualHolidaysRepository;
            _mapper = mapper;
            _responseHandler = responseHandler;
        }
        [HttpGet("GetHolidays")]
        public async Task<IActionResult> GettAllHolidays()
        {
            dynamic response;
            var holidays = _annualHolidaysRepository.GetTableAsTracking();
            if(holidays == null || holidays.Count == 0)
            {
                response = _responseHandler.NotFound<string>("No Holidays Found");
                return NotFound(response);
            }
           var mappedSettings= _mapper.Map<List<AnnualHolidays>, List<AnnualHolidaysQueryDTO>>(holidays);
            response = _responseHandler.Success<List<AnnualHolidaysQueryDTO>>(mappedSettings);
            return Ok(response);

        }
        [HttpPut("EditHoliday")]
        public async Task<IActionResult>EditHoliday(AnnualHolidaysCommandDTO annualHolidaysCommandDTO)
        {
            dynamic response;
            if(ModelState.IsValid)
            {
                var mappedSettings = _mapper.Map<AnnualHolidaysCommandDTO, AnnualHolidays>(annualHolidaysCommandDTO);
               await _annualHolidaysRepository.UpdateAsync(mappedSettings);
                response =   _responseHandler.Success<AnnualHolidaysCommandDTO>(annualHolidaysCommandDTO);
                return Ok(response);
            }
            response = _responseHandler.NotFound<string>("No Holiday Found");
            return NotFound(response);
          
        }
        [HttpDelete("DeleteHoliday")]
        public async Task<IActionResult>DeleteHoliday(int holidayId)
        {
            dynamic response;
            var entity = await _annualHolidaysRepository.GetByIdAsync(holidayId);
            if (entity == null)
            {
                response = _responseHandler.NotFound<string>("No Holiday found");
                return NotFound(response);
            }
            _annualHolidaysRepository.DeleteAsync(entity);
            response = _responseHandler.Success<string>("Deleted Successfully");
            return Ok(response);
        }
        [HttpPost("CreateHoliday")]
        public async Task<IActionResult>CreateHoliday(AnnualHolidaysCommandDTO annualHolidaysCommandDTO)
        {
            dynamic response;
            if (ModelState.IsValid)
            {
                var mappedHolidayEntity = _mapper.Map<AnnualHolidaysCommandDTO, AnnualHolidays>(annualHolidaysCommandDTO);
                _annualHolidaysRepository.AddAsync(mappedHolidayEntity);
                response = _responseHandler.Success<string>("Added Successfully");
                return Ok(response);

            }
            response = _responseHandler.NotFound<string>("Enter Valid Data");
            return NotFound(response);
        }
    }
}
