using System.Collections.Generic;
using System.Linq;
using Chatman.Api.RequestModels;
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
            ICollection<Conversation> allConvs = convRepository.GetAll();

            return Ok(allConvs);
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<Conversation> GetById(string id)
        {
            var conversation = convRepository.GetAll().SingleOrDefault(x => x.Id.Value == id);

            return Ok(conversation);
        }

        [HttpPost]
        public ActionResult Add(ConversationRequestModel conv)
        {
            var convId = new ConversationId(conv.Id);
            var userIds = new List<UserId>();
            ICollection<UserId> usersParticipatingIds = new List<UserId>();

            foreach (string id in conv.UsersParticipatingIds)
            {
                var userParticipatingId = new UserId(id);
                usersParticipatingIds.Add(userParticipatingId);

            }

            Conversation convToBeAdded = new Conversation(convId, usersParticipatingIds);

            bool found = convRepository.GetAll().Any(x => x.Id == convToBeAdded.Id);
            if (found) return Ok();

            convRepository.Add(convToBeAdded);
            return Ok();
        }

        [HttpPost]
        [Route("message")]
        public ActionResult AddMessageToConv(MessageRequestModel message)
        {
            if (string.IsNullOrEmpty(message.AuthorId))
                return BadRequest("AuthorId cannot be null");

            if (string.IsNullOrEmpty(message.Text))
                return BadRequest("Message Text should not be empty");

            if (string.IsNullOrEmpty(message.ConvId))
                return BadRequest("Conversation id cannot be null");
            
            Conversation conv = convRepository
                .GetById(new ConversationId(message.ConvId));

            if (conv is null)
                return NotFound("The conversation that you are trying to add message to does not exist");

            var messageToBeAdded = new Message(new UserId(message.AuthorId),message.Text);
            conv.AddMessage(messageToBeAdded);

            return Ok();

        }

    }
}