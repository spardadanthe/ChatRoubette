using System.Collections.Generic;
using System.Linq;
using Chatman.Api.RequestModels;
using Chatman.Api.ResponseModels;
using Microsoft.AspNetCore.Mvc;
using Persistence.Interfaces;

namespace Chatman.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConversationsController : ControllerBase
    {
        private readonly IRepository<Conversation> convRepository;

        public ConversationsController(IRepository<Conversation> convRepository)
        {
            this.convRepository = convRepository;
        }

        [HttpGet]
        public ActionResult<ICollection<ConversationResponseModel>> Get()
        {
            IEnumerable<Conversation> allConversations = convRepository.GetAll();
            if (allConversations is null) return NotFound("There are currently no conversations");

            IEnumerable<ConversationResponseModel> response = ListConvResponseModelConverter(allConversations);

            return Ok(response);
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<ConversationResponseModel> GetById(string id)
        {
            Conversation conversation = convRepository.GetById(new BaseId(id));

            ConversationResponseModel response = new ConversationResponseModel(conversation);

            return Ok(response);
        }

        [HttpPost]
        public ActionResult Add(ConversationRequestModel conv)
        {
            var convId = new ConversationId(conv.Id);
            var userIds = new List<UserId>();
            var ownerId = new UserId(conv.OwnerId);

            ICollection<UserId> usersParticipatingIds = new List<UserId>();

            foreach (string id in conv.UsersParticipatingIds)
            {
                var userParticipatingId = new UserId(id);
                usersParticipatingIds.Add(userParticipatingId);
            }

            Conversation convToBeAdded = new Conversation(convId, usersParticipatingIds, ownerId);

            bool found = convRepository.GetAll()
                .Any(x => x.Id.Value.Equals(convToBeAdded.Id.Value));
            if (found) return Ok();

            convRepository.Add(convToBeAdded);
            return Ok();
        }

        private IEnumerable<ConversationResponseModel> ListConvResponseModelConverter(IEnumerable<Conversation> allConversations)
        {
            var conversationResponseModels = new List<ConversationResponseModel>();

            foreach (var conversation in allConversations)
            {
                ConversationResponseModel conversationResponseModel = new ConversationResponseModel(conversation);
                
                conversationResponseModels.Add(conversationResponseModel);
            }

            return conversationResponseModels;
        }

        
    }
}