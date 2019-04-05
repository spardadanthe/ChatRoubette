using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chatman.Api.RequestModels;
using Microsoft.AspNetCore.Http;
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
        public ActionResult GetMessagesByConvId()
        {
            return Ok();
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