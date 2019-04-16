﻿using AutoMapper;
using Chatman.Persistence.EF.Dtos;
using System.Collections.Generic;
using System.Linq;

namespace Chatman.Persistence.EF.Profiles
{
    public class ConversationProfile : Profile
    {
        public ConversationProfile()
        {
            CreateMap<string, IBaseId>()
                .ConvertUsing(f => new BaseId(f));

            CreateMap<string, UserId>()
                .ConvertUsing(f => new UserId(f));

            CreateMap<BaseId, UserId>().ConstructUsing(f => new UserId(f.Value));

            CreateMap<Conversation, ConversationDto>()
                .ForMember(x => x.ConversationUsers, y => y.MapFrom(src => src.UsersParticipatingIds));


            CreateMap<ConversationDto, Conversation>()
                .ForMember(x => x.OwnerId, opt => opt.MapFrom(src => src.OwnerId))
                .ForMember(x => x.UsersParticipatingIds, y => y.MapFrom(src => src.ConversationUsers));

            CreateMap<BaseId, UserId>();

            CreateMap<UserId, ConversationUser>()
                .ConstructUsing(cu => new ConversationUser { UserId = cu.Value });

            CreateMap<ConversationUser, UserId>()
                .ConstructUsing(userid => new UserId(userid.UserId));


        }
    }


}
