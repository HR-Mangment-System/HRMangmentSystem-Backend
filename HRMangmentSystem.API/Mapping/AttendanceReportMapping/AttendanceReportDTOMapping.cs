using AutoMapper;
using HRMangmentSystem.API.DTOS.AnnualHolidaysDTO;
using HRMangmentSystem.API.DTOS.AttendanceReportDTO;
using HRMangmentSystem.API.DTOS.DepartmentDTO;
using HRMangmentSystem.DataAccessLayer.Models;

namespace HRMangmentSystem.API.Mapping.AttendanceReportMapping
{
    public class AttendanceReportDTOMapping:Profile
    {
        public AttendanceReportDTOMapping()
        {

            CreateMap<dynamic, AttendanceReportQueryDto>()
                .ForMember(dest => dest.EmployeeNationalId, opt => opt.MapFrom(src => src.EmployeeNationalId))
                .ForMember(dest => dest.Employee, opt => opt.MapFrom(src => src.EmployeeName))
                .ForMember(dest => dest.Department, opt => opt.MapFrom(src => src.DepartmentName));

        }
    }
}
