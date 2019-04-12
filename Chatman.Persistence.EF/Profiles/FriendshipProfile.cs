using AutoMapper;
using Chatman.Persistence.EF.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chatman.Persistence.EF.Profiles
{
    public  class FriendshipProfile : Profile
    {
        public FriendshipProfile()
        {
            CreateMap<string, IBaseId>()
                .ConvertUsing(f => new BaseId(f));

            CreateMap<string, UserId>()
                .ConvertUsing(f => new UserId(f));

            CreateMap<string, FriendshipId>()
                .ConvertUsing(f => new FriendshipId(f));

            CreateMap<BaseId, FriendshipId>()
                .ConvertUsing(f => new FriendshipId(f.Value));

            CreateMap<Friendship, FriendshipDto>();
            CreateMap<FriendshipDto, Friendship>();
        }
    }
}
