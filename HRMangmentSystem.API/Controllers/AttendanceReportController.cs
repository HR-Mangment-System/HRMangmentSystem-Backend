using AutoMapper;
using HRManagementSystem.DataAccessLayer.Models;
using HRMangmentSystem.API.DTOS.AttendanceReportDTO;
using HRMangmentSystem.API.DTOS.EmployeeDTO;
using HRMangmentSystem.API.ResponseBase;
using HRMangmentSystem.BusinessLayer.IRepository;
using HRMangmentSystem.DataAccessLayer.Models;
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
        private readonly IEmployeeRepository _employeeRepository;
        public AttendanceReportController(IAttendanceReportRepository attendanceReportRepository, IMapper mapper, ResponseHandler responseHandler, IEmployeeRepository employeeRepository)
        {
            _attendanceReportRepository = attendanceReportRepository;
            _mapper = mapper;
            _responseHandler = responseHandler;
            _employeeRepository = employeeRepository;
        }
        [HttpGet("GetAttendanceReport")]
        public async Task<IActionResult> GetAttendanceReport()
        {
            dynamic resposne;
            var attendanceReport = _attendanceReportRepository.GetTableAsTracking();
            if (attendanceReport == null)
            {
                resposne = _responseHandler.NotFound<string>("No Reports Found");
                return NotFound(resposne);
            }
            var mappedData = _mapper.Map<List<AttendanceRecord>, List<AttendanceReportQueryDto>>(attendanceReport);
            resposne = _responseHandler.Success(mappedData);
            return Ok(resposne);
        }
        [HttpPut("UpdateAttendanceReport")]
        public async Task<IActionResult> UpdateAttendaceRecorf(AttendanceReportCommandDto attendanceReportCommandDto)
        {
            dynamic response;
            if (ModelState.IsValid)
            {
                var attendanceReport = _mapper.Map<AttendanceReportCommandDto, AttendanceRecord>(attendanceReportCommandDto);
                await _attendanceReportRepository.UpdateAsync(attendanceReport);
                response = _responseHandler.Success(attendanceReport);
                return Ok(response);

            }
            response = _responseHandler.BadRequest<string>("Invalid Data");
            return BadRequest(response);
        }
        [HttpPost("AddAttendanceReport")]
        public async Task<IActionResult> AddAttendanceReport(AttendanceReportCommandDto attendanceReportCommandDto)
        {
            dynamic response;
            if (ModelState.IsValid)
            {
                var employee = _mapper.Map<Employee, EmployeeQueryDTO>(await _employeeRepository.GetEmployeeByNationalId(attendanceReportCommandDto.EmployeeNationalId));
                if (employee.AttendanceTime != TimeOnly.Parse(attendanceReportCommandDto.ArrivalTime))
                {
                    attendanceReportCommandDto.LateHours = (TimeOnly.Parse(attendanceReportCommandDto.ArrivalTime) - employee.AttendanceTime).Hours;
                }
                if (employee.DepartureTime != TimeOnly.Parse(attendanceReportCommandDto.DepartureTime))
                {
                    attendanceReportCommandDto.EarlyLeaveHours = (employee.DepartureTime - TimeOnly.Parse(attendanceReportCommandDto.DepartureTime)).Hours;
                }
                else if (employee.DepartureTime < TimeOnly.Parse(attendanceReportCommandDto.DepartureTime))
                {
                    attendanceReportCommandDto.OvertimeHours = (TimeOnly.Parse(attendanceReportCommandDto.DepartureTime) - employee.DepartureTime).Hours;
                }
                var attendanceReport = _mapper.Map<AttendanceReportCommandDto, AttendanceRecord>(attendanceReportCommandDto);
                await _attendanceReportRepository.AddAsync(attendanceReport);
                response = _responseHandler.Success("Added Successfully");
                return Ok(response);
            }
            response = _responseHandler.BadRequest<string>("Invalid Data");
            return BadRequest(response);
        }

        [HttpDelete("DeleteAttendanceReport")]
        public async Task<IActionResult> DeleteAttendanceReport(int id)
        {
            dynamic response;
            var attendanceReport = await _attendanceReportRepository.GetByIdAsync(id);
            if (attendanceReport == null)
            {
                response = _responseHandler.NotFound<string>("No Report Found");
                return NotFound(response);
            }
            await _attendanceReportRepository.DeleteAsync(attendanceReport);
            response = _responseHandler.Success($"Attendance Deleted Successfully");
            return Ok(response);
        }

    }

}
