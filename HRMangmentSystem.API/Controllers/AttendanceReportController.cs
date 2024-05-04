using AutoMapper;
using HRMangmentSystem.API.ResponseBase;
using HRMangmentSystem.BusinessLayer.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRMangmentSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendanceReportController : ControllerBase
    {
        private readonly IAttendanceReportRepository _attendanceReportRepository;
        private readonly IMapper _mapper;
        private readonly ResponseHandler _responseHandler;
        public AttendanceReportController(IAttendanceReportRepository attendanceReportRepository, IMapper mapper, ResponseHandler responseHandler)
        {
            _attendanceReportRepository = attendanceReportRepository;
            _mapper = mapper;
            _responseHandler = responseHandler;
        }
        [HttpGet]
        public async Task<IActionResult> GetAttendanceReport() {

           var attendanceReport= _attendanceReportRepository.GetTableAsTracking();
            if(attendanceReport == null)
            {
                return NotFound();
            }
            return Ok(attendanceReport);
        }
    }
}
