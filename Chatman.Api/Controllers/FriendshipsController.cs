using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chatman.Api.ResponseModels;
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
        public ActionResult<IEnumerable<FriendshipResponseModel>> Get()
        {
            IEnumerable<Friendship> friendships = friendshipsRepo.GetAll();

            if (friendships is null || friendships.Any())
                return NotFound("There are no friendships");

            List<FriendshipResponseModel> response = ListFriendshipModelConverter(friendships);

            return Ok(response);
        }



        [HttpGet]
        [Route("{userId}")]
        public ActionResult<IEnumerable<FriendshipResponseModel>> GetByUserId(string userId)
        {
            var friendships = friendshipsRepo.GetAll()
                .Where(x => x.FirstUserId.Value == userId || x.SecondUserId.Value == userId);

            if (friendships is null || friendships.Any())
                return NotFound("There is no such friendship");

            List<FriendshipResponseModel> response = ListFriendshipModelConverter(friendships);

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

            var friendship = new Friendship(firstUserId, secondUserId);

            friendshipsRepo.Add(friendship);


            return Ok();

        }

        private List<FriendshipResponseModel> ListFriendshipModelConverter(IEnumerable<Friendship> friendships)
        {
            List<FriendshipResponseModel> result = new List<FriendshipResponseModel>();

            foreach (Friendship friendship in friendships)
            {
                FriendshipResponseModel responseModel = new FriendshipResponseModel(friendship);

                result.Add(responseModel);
            }

            return result;

        }
    }


}