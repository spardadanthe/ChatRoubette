using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chatman;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChatApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FriendsController : ControllerBase
    {
        public static HashSet<User> Friends = new HashSet<User>();

        // GET: api/Friends
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return Friends;
        }

        // GET: api/Friends/Vanko
        [HttpGet("{name}", Name = "Get")]
        public User Get(string name)
        {
            return Friends.SingleOrDefault(x => x.Username == name);
        }

        // POST: api/Friends
        [HttpPost]
        public void Post([FromBody] User friend)
        {
            if (!Friends.Any(user => user.Username == friend.Username)) Friends.Add(friend);
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{name}")]
        public void Delete(string name)
        {
            Friends.Remove(Friends.SingleOrDefault(x => x.Username == name));
        }
    }
}
