using AutoMapper;
using Chatman.Persistence.EF.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chatman.Persistence.EF.Profiles
{
    public class MessageProfile : Profile
    {
        public MessageProfile()
        {
            CreateMap<string, IBaseId>()
                .ConvertUsing(f => new BaseId(f));

            CreateMap<string, UserId>()
                .ConvertUsing(f => new UserId(f));

            CreateMap<string, ConversationId>()
                .ConvertUsing(f => new ConversationId(f));

            CreateMap<Message, MessageDto>()
                .ForMember(x => x.ConversationId,opt => opt.MapFrom(src => src.ConvId));
            CreateMap<MessageDto, Message>()
                .ForMember(x => x.ConvId,opt => opt.MapFrom(src => src.ConversationId));
        }
    }
}
