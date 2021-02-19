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
    public class ConversationsController : ControllerBase
    {
        public static HashSet<Conversation> Conversations = new HashSet<Conversation>();
        // GET: api/Conversations
        [HttpGet]
        public IEnumerable<Conversation> Get()
        {
            return Conversations;
        }

        // GET: api/Conversations/id
        [HttpGet("{id}", Name = "GetConvById")]
        public Conversation Get(string id)
        {
            return Conversations.SingleOrDefault(x => x.Id.Value == id);
        }

        // POST: api/Conversation
        [HttpPost()]
        public void Post(Conversation conv)
        {
            SaveConv(conv);
        }



        // PUT: api/Conversation/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        public static void SaveConv(Conversation conv)
        {
            try
            {
                Conversations.RemoveWhere(x => x.Id.Value == conv.Id.Value);
            }
            catch (System.Exception)
            {
            }
            finally
            {
                Conversations.Add(conv);
            }
        }
    }
}
