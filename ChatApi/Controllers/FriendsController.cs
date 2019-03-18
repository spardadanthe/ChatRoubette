using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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
        public FriendsController()
        {
            //Test if ListFriends works
            //User test = new User("TestGoshko");
            //User goshkosFriend = new User("Friend of Goshko 1");
            //User goshkosFriend2 = new User("Friend of Goshko 2");
            //test.AddFriend(goshkosFriend.Id);
            //test.AddFriend(goshkosFriend2.Id);
            //UserProvider.SaveUser(goshkosFriend);
            //UserProvider.SaveUser(goshkosFriend2);
            //UserProvider.SaveUser(test);

        }

        // GET: api/Friends/name
        [HttpGet("{name}",Name = "GetUserFriendsByName")]
        public IEnumerable<User> GetFriendsForUser(string name)
        {
            return UserProvider.GetUserFriends(name);
        }


        //POST: api/Friends
        [HttpPost]
        public IActionResult Post([FromBody] AddFriendRequest addFriendRequest)
        {
            var firstUser = UserProvider.GetUserById(addFriendRequest.currentUserId);
            var secondUser = UserProvider.GetUserById(addFriendRequest.userToBeAddedId);


            if (firstUser == null || secondUser == null)
            {
                return Ok();
            }

            firstUser.AddFriend(addFriendRequest.userToBeAddedId);
            secondUser.AddFriend(addFriendRequest.currentUserId);

            UserProvider.SaveUser(firstUser);
            UserProvider.SaveUser(secondUser);

            return Ok();
        }
    }
}
