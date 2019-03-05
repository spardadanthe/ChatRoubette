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
        public static List<Conversation> Conversations = new List<Conversation>();
        // GET: api/Conversations
        [HttpGet]
        public IEnumerable<Conversation> Get()
        {
            return Conversations;
        }

        // GET: api/Conversations/
        [HttpGet]
        [Route("{name}/{name2}")]
        public Conversation Get(string name, string name2)
        {
            
            //var conv1 = new Conversation();
            //var user1 = new User("vanko");
            //var user2 = new User("vanko2");
            //conv1.UsersParticipating.Add(user1);
            //conv1.UsersParticipating.Add(user2);
            //var mess = new Message();
            //conv1.History.Add(mess);
            //Conversations.Add(conv1);
            //Conversation asd = Conversations.SingleOrDefault(x => (x.UsersParticipating.Contains(user1) && x.UsersParticipating.Contains(user2)));

            //TODO FIX THIS
            return Conversations.SingleOrDefault(x => x.UsersParticipatingId.Any(y => y.Value == name) && x.UsersParticipatingId.Any(z => z.Value == name2));
        }

        // POST: api/Conversation
        [HttpPost]
        public void Post([FromBody] Conversation conv)
        {
            Conversations.Add(conv);
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
    }
}
