using AutoMapper;
using HRManagementSystem.DataAccessLayer.Models;
using HRMangmentSystem.API.DTOS.EmployeeDTO;

namespace HRMangmentSystem.API.Mapping.EmployeeMapping
{
    public class EmployeeDTOMapping : Profile
    {
        public EmployeeDTOMapping()
        {
            CreateMap<Employee, EmployeeQueryDTO>()
            .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Department.Name));
            CreateMap<EmployeeCommandDTO, Employee>(); 
        }

    }

}
