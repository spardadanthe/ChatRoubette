using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;


namespace Chatman.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        public UsersController()
        {
        }

        //[HttpGet]
        //public IActionResult GetAll()
        //{
        //    ICollection<User> allUsers = usersRepository.GetAll();

        //    return new OkObjectResult(allUsers.First());
        //}

        //[HttpGet]
        //[Route("{id}")]
        //public User GetById(string id)
        //{
        //    UserId userId = new UserId(id);
        //    User user = usersRepository.GetById(userId);

        //    return user;
        //}


        //[HttpGet]
        //[Route("username/{username}")]
        //public User GetByUsername(string username)
        //{
        //    User user = usersRepository.GetByUsername(username);

        //    return user;
        //}

        //[HttpGet]
        //[Route("{id}/friends")]
        //public IEnumerable<User> GetUserFriends(string id)
        //{
        //    IEnumerable<User> userFriends = usersRepository.GetUserFriends(id);

        //    return userFriends;
        //}
    }
}