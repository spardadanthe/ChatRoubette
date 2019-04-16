using AutoMapper;
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
                .ForMember(x => x.ConversationUsers, y => y.MapFrom(src => src.UsersParticipatingIds))
                .ForMember(x => x.BlockedUsers,y => y.MapFrom(src => src.BlockedUsersIds));


            CreateMap<ConversationDto, Conversation>()
                .ForMember(x => x.OwnerId, opt => opt.MapFrom(src => src.OwnerId))
                .ForMember(x => x.UsersParticipatingIds, y => y.MapFrom(src => src.ConversationUsers))
                .ForMember(x => x.BlockedUsersIds, y => y.MapFrom(src => src.BlockedUsers));

            CreateMap<BaseId, UserId>();

            CreateMap<UserId, ConversationUser>()
                .ConstructUsing(userId => new ConversationUser { UserId = userId.Value });

            CreateMap<ConversationUser, UserId>()
                .ConstructUsing(cu => new UserId(cu.UserId));

            CreateMap<UserId, ConversationBlockedUsers>()
                .ConstructUsing(userId => new ConversationBlockedUsers { UserId = userId.Value });

            CreateMap<ConversationBlockedUsers, UserId>()
                .ConstructUsing(cbu => new UserId(cbu.UserId));



        }
    }


}
