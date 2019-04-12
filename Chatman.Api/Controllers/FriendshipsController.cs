using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Persistence.Interfaces;

namespace Chatman.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FriendshipsController : ControllerBase
    {
        private readonly IRepository<Friendship> friendshipsRepo;

        public FriendshipsController(IRepository<Friendship> friendshipsRepo)
        {
            this.friendshipsRepo = friendshipsRepo;
        }

        [HttpGet]
        public ActionResult Get()
        {
            var friendships = friendshipsRepo.GetAll();

            if (friendships is null || friendships.Count == 0)
                return NotFound("There are no friendships");


            //var result = new FrienshipsResponse { Result = friendships.Select(x => x.Id.Value).ToList() };

            //var first = new Friendship(new UserId("1"), new UserId("2"));
            //var second = new Friendship(new UserId("1"), new UserId("2"));

            //first.Equals(second);

            return Ok(friendships);
        }

            

        [HttpGet]
        [Route("{userId}")]
        public ActionResult GetByUserId(string userId)
        {
            var friendships = friendshipsRepo.GetAll()
                .Where(x => x.FirstUserId.Value == userId || x.SecondUserId.Value == userId);

            if (friendships is null || friendships.Count() <= 0)
                return NotFound("There is no such friendship");

            return Ok(friendships);
        }

        [HttpPost]
        public ActionResult Add(AddFriendRequestModel friendRequestModel)
        {
            if (friendRequestModel is null) return BadRequest();

            if (string.IsNullOrEmpty(friendRequestModel.CurrentUserId) 
                || string.IsNullOrEmpty(friendRequestModel.UserToBeAddedId))
                return BadRequest("One or both of ther user ids is/are empty");

            var firstUserId = new UserId(friendRequestModel.CurrentUserId);
            var secondUserId = new UserId(friendRequestModel.UserToBeAddedId);

            var friendship = new Friendship(firstUserId,secondUserId);

            friendshipsRepo.Add(friendship);

            
            return Ok();

        }
    }

    public class FrienshipsResponse
    {
        public ICollection<string> Result { get; set; }
    }
}