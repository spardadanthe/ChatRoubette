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
        public ActionResult<ICollection<Conversation>> Get()
        {
            ICollection<Conversation> allConversations = convRepository.GetAll();
            if (allConversations is null) return NotFound("There are currently no conversations");

            ICollection<ConversationResponseModel> response = ConvResponseModelConverter(allConversations);

            return Ok(response);
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<Conversation> GetById(string id)
        {
            //var conversation = convRepository.GetAll().SingleOrDefault(x => x.Id.Value == id);
            var conversation = convRepository.GetById(new BaseId(id));

            return Ok(conversation);
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

            Conversation convToBeAdded = new Conversation(convId, usersParticipatingIds,ownerId);

            bool found = convRepository.GetAll().Any(x => x.Id == convToBeAdded.Id);
            if (found) return Ok();

            convRepository.Add(convToBeAdded);
            return Ok();
        }

        private ICollection<ConversationResponseModel> ConvResponseModelConverter(ICollection<Conversation> allConversations)
        {
            var conversationResponseModels = new List<ConversationResponseModel>();

            foreach (var conversation in allConversations)
            {
                var blockedUsersIds = conversation.BlockedUsersIds.Select(x=>x.Value);
                var usersParticipatingIds = conversation.BlockedUsersIds.Select(x => x.Value);
                
                var conversationResponseModel = new ConversationResponseModel(conversation.Id.Value,
                    conversation.OwnerId.Value, blockedUsersIds, usersParticipatingIds);

                conversationResponseModels.Add(conversationResponseModel);
            }

            return conversationResponseModels;
        }
    }
}