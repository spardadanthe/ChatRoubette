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
    public class UserController : ControllerBase
    {
        // GET: api/User/all
        [HttpGet("all", Name = "GetALL")]
        public IEnumerable<User> Get()
        {
            return UserProvider.GetAllUsers();
        }


        // GET: api/User/Vanko
        [HttpGet("{name}", Name = "GetUserByName")]
        public User Get(string name)
        {
            return UserProvider.GetUserByUsername(name);
        }

        // GET: api/User/getbyid
        [HttpGet("getbyid/{id}", Name = "GetUserById")]
        public User GetById(string id)
        {
            UserId userId = new UserId(id);
            return UserProvider.GetUserById(userId);
        }

        // POST: api/User
        [HttpPost]
        public void AddCurrentUser([FromBody] User user)
        {
           // User user = new User(username);
            UserProvider.SaveUser(user);
        }
    }
}