using AutoMapper;
using HRMangmentSystem.API.DTOS.GroupDTO;
using HRMangmentSystem.API.DTOS.PermissionDTO;
using HRMangmentSystem.DataAccessLayer.Models;

namespace HRMangmentSystem.API.Mapping.GroupMapping
{
    public class GroupCommandMapping : Profile
    {
        public GroupCommandMapping()
        {
            CreateMap<GroupCommandDTO, Group>().
                ForMember(dest => dest.Permissions, opt => opt.MapFrom(src => src.Permissions));

            CreateMap<PermissionCommandDTO, Permission>();

            CreateMap<Group, GroupQueryDTO>();
        }
    }
}
