using AutoMapper;
using Chatman.Persistence.EF.Dtos;

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
            CreateMap<Conversation, ConversationDto>();
            CreateMap<ConversationDto, Conversation>()
                .ForMember(x => x.OwnerId, opt => opt.MapFrom(src => src.OwnerId));
            CreateMap<BaseId, UserId>();
        }
    }


}
