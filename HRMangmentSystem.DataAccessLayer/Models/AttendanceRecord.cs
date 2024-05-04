using HRManagementSystem.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMangmentSystem.DataAccessLayer.Models
{
        public class AttendanceRecord
        {

            public int Id { get; set; }
            [ForeignKey("Employee")]
            public string EmployeeNationalId { get; set; }
            public virtual Employee Employee { get; set; }
            public DateOnly? AttendanceDate { get; set; }
            public TimeOnly? ArrivalTime { get; set; }
            public TimeOnly? DepartureTime { get; set; }
            public bool Isabsent { get; set; } = false;
            public bool? IsOnTime { get; set; }
        }
}
