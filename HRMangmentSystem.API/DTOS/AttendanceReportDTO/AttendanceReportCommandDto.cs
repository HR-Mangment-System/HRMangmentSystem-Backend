using HRMangmentSystem.API.DtoValidators.AttendanceValidators;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRMangmentSystem.API.DTOS.AttendanceReportDTO
{
    public class AttendanceReportCommandDto
    {
        public int? Id { get; set; }
        public string EmployeeNationalId { get; set; }
        public string AttendanceDate { get; set; }
        [ArrivalAndDepartureTime]
        public string? ArrivalTime { get; set; }
        [ArrivalAndDepartureTime]
        public string? DepartureTime { get; set; }
        [NotMapped]
        public int? LateHours { get; set; }
        [NotMapped]
        public int? EarlyLeaveHours { get; set; }
        [NotMapped]
        public int? OvertimeHours { get; set; }

    }
}
