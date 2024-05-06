using HRMangmentSystem.BusinessLayer.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRMangmentSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalaryReportController : ControllerBase
    {
        private readonly ISalaryRepository _salaryRepository;
        public SalaryReportController(ISalaryRepository salaryRepository)
        {
            _salaryRepository = salaryRepository;
        }
        [HttpGet("GetSalaries")]
        public IActionResult GetSalaries(string date)
        {
            return Ok(_salaryRepository.CalculateSalary(null, DateOnly.Parse(date)));
        }
    }
}
