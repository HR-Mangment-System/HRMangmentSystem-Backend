﻿using AutoMapper;
using HRMangmentSystem.API.DTOS;
using HRMangmentSystem.DataAccessLayer.Models;

namespace HRMangmentSystem.API.Mapping
{
    public class AccountPostMapping : Profile
    {
        public AccountPostMapping()
        {
            CreateMap<AccountPostDTO, ApplicationUser>();
        }
    }
}
