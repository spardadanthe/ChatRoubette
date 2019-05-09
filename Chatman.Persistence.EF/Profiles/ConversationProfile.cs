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

            CreateMap<UserId, string>()
                .ConvertUsing(id => id.Value);

            CreateMap<BaseId, UserId>().ConstructUsing(f => new UserId(f.Value));

            CreateMap<Conversation, ConversationDto>()
                .ForMember(x => x.ConversationUsers, y => y.MapFrom(src => src.UsersParticipatingIds))
                .ForMember(x => x.ConversationBlockedUsers, y => y.MapFrom(src => src.BlockedUsersIds));


            CreateMap<ConversationDto, Conversation>()
                .ForMember(x => x.OwnerId, opt => opt.MapFrom(src => src.OwnerId))
                .ForMember(x => x.UsersParticipatingIds, y => y.MapFrom(src => src.ConversationUsers))
                .ForMember(x => x.BlockedUsersIds, y => y.MapFrom(src => src.ConversationBlockedUsers));

            CreateMap<BaseId, UserId>();

            CreateMap<UserId, ConversationUser>()
                .ConstructUsing(userId => new ConversationUser { UserId = userId.Value });

            CreateMap<IEnumerable<UserId>, IEnumerable<ConversationUser>>()
                .ConstructUsing(userIds => userIds.Select(x => new ConversationUser { UserId = x.Value }).ToList());
            

            CreateMap<ConversationUser, UserId>()
                .ConstructUsing(cu => new UserId(cu.UserId));

            CreateMap<UserId, ConversationBlockedUsers>()
                .ConstructUsing(userId => new ConversationBlockedUsers { UserId = userId.Value });

            CreateMap<ConversationBlockedUsers, UserId>()
                .ConstructUsing(cbu => new UserId(cbu.UserId));

            CreateMap<ICollection<UserId>, ICollection<ConversationUser>>()
                      .ConstructUsing(userIds => userIds.Select(x => new ConversationUser { UserId = x.Value }).ToList());



        }
    }


}
