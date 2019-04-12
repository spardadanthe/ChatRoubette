using System.Linq;
using Chatman.Api.RequestModels;
using Microsoft.AspNetCore.Mvc;
using Persistence.Interfaces;

namespace Chatman.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IRepository<Message> messageRepo;

        public MessagesController(IRepository<Message> messageRepo)
        {
            this.messageRepo = messageRepo;
        }

        [HttpGet]
        [Route("{messageId}")]
        public ActionResult GetById(string messageId)
        {
            if (string.IsNullOrEmpty(messageId)) return BadRequest("There is no message with such id");

            var found = messageRepo.GetAll().Any(x => x.Id.Value == messageId);

            if (found)
            {
                var message = messageRepo.GetById(new BaseId(messageId));
                return Ok(message);
            }

            return NotFound("Message was not found");


        }

        [HttpGet]
        [Route("conversation/{convId}")]
        public ActionResult GetMessagesByConvId(string convId)
        {
            if (string.IsNullOrEmpty(convId))
                return BadRequest("No conversation id is given");

            if (messageRepo.GetAll().Any(x => x.ConvId.Value == convId) == false)
                return NotFound("There are not messages in this conversation");

            var messages = messageRepo.GetAll().
                Where(x => x.ConvId.Value == convId);

            return Ok(messages);

        }

        [HttpPost]
        public ActionResult AddMessage([FromBody] MessageRequestModel message)
        {
            if (message is null) return BadRequest("There was no message posted");

            if (string.IsNullOrEmpty(message.AuthorId))
                return BadRequest("AuthorId cannot be null");

            if (string.IsNullOrEmpty(message.Text))
                return BadRequest("Message Text should not be empty");

            if (string.IsNullOrEmpty(message.ConvId))
                return BadRequest("Conversation id cannot be null");

            var messageToBeAdded = new Message(new UserId(message.AuthorId),
                new ConversationId(message.ConvId), message.Text);

            messageRepo.Add(messageToBeAdded);

            return Ok();

        }
    }
}