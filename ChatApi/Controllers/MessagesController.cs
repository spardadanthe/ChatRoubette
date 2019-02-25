using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chatman;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChatApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        public static List<Message> messages = new List<Message>();

        // GET: api/Message
        [HttpGet]
        public List<Message> Get()
        {
            //Message mess = new Message();
            //mess.Sender = new User("nick");
            //mess.Text = "text";
            //messages.Add(mess);
            return messages;
        }

        // POST: api/Message
        [HttpPost]
        public void Post([FromBody] Message message)
        {
            if (((message.Sender is null) || string.IsNullOrEmpty(message.Text)))
            {
                throw new ArgumentException("Every message must have a sender and text");
            }

            messages.Add(message);
        }
    }
}
