﻿using AutoMapper;
using Chatman.Persistence.EF.Dtos;

namespace Chatman.Persistence.EF.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {

            CreateMap<string, IBaseId>()
                .ConvertUsing(f => new BaseId(f));

            CreateMap<User, UserDto>();

            CreateMap<UserDto, User>();
        }
    }


}
