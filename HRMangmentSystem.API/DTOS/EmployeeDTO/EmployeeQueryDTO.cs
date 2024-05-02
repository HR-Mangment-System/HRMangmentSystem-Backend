using HRMangmentSystem.DataAccessLayer.CustomValidators;
using HRMangmentSystem.DataAccessLayer.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HRMangmentSystem.API.DTOS.EmployeeDTO
{
    public class EmployeeQueryDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public char Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Nationality { get; set; }
        public string NationalId { get; set; }
        public DateTime HireDate { get; set; }
        public double Salary { get; set; }
        public DateTime AttendanceTime { get; set; }
        public DateTime DepartureTime { get; set; }
        public bool IsDeleted { get; set; }
        public string DepartmentName { get; set; }

    }
}
