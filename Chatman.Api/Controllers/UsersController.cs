using System.Collections.Generic;
using System.Linq;
using Chatman.Api.ResponseModels;
using Microsoft.AspNetCore.Mvc;
using Persistence.Interfaces;

namespace Chatman.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IRepository<User> usersRepository;
        private readonly IRepository<Friendship> friendshipsRepo;

        public UsersController(IRepository<User> usersRepo, IRepository<Friendship> friendshipsRepo)
        {
            usersRepository = usersRepo;
            this.friendshipsRepo = friendshipsRepo;
        }

        [HttpGet]
        public ActionResult<ICollection<UserResponseModel>> GetAll()
        {
            IEnumerable<User> allUsers = usersRepository.GetAll();

            List<UserResponseModel> response = new List<UserResponseModel>();

            foreach (var user in allUsers)
            {
                response.Add(new UserResponseModel(user));
            }

            return Ok(response);
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<UserResponseModel> GetById(string id)
        {
            if (string.IsNullOrEmpty(id)) return BadRequest();

            UserId userId = new UserId(id);
            User user = usersRepository.GetById(userId);

            if (user is null) return NotFound("There is no user with such id");

            UserResponseModel response = new UserResponseModel(user);

            return Ok(response);
        }


        [HttpGet]
        [Route("username/{username}")]
        public ActionResult<UserResponseModel> GetByUsername(string username)
        {
            if (string.IsNullOrEmpty(username)) return BadRequest();

            User user = usersRepository.GetAll().FirstOrDefault(x => x.Username == username);

            if (user is null) return BadRequest("There is no user with that username");;

            UserResponseModel response = new UserResponseModel(user);

            return Ok(response);
        }

        [HttpGet]
        [Route("{id}/friends")]
        public ActionResult<IEnumerable<UserResponseModel>> GetFriendsByUserId(string id)
        {
            var userId = new UserId(id);
            var listWithFriendIds = new List<UserId>();
            var listWithFriends = new List<User>();

            IEnumerable<Friendship> listOfFriendships = friendshipsRepo.GetAll();

            foreach (Friendship  friendship in listOfFriendships)
            {
                if (friendship.FirstUserId == userId)
                {
                    listWithFriendIds.Add(friendship.SecondUserId);
                }
                else if (friendship.SecondUserId == userId)
                {
                    listWithFriendIds.Add(friendship.FirstUserId);
                }
            }

            foreach (UserId friendId in listWithFriendIds)
            {
                var friend = usersRepository.GetById(friendId);

                if (friend is null == false) listWithFriends.Add(friend);
            }

            List<UserResponseModel> result = new List<UserResponseModel>();

            foreach (User friend in listWithFriends)
            {
                result.Add(new UserResponseModel(friend));
            }

            return Ok(result);
        }

        [HttpPost]
        public ActionResult AddUser(string username)
        {
            if (string.IsNullOrEmpty(username)) return BadRequest("Every user must have a name");


            var user = new User(username);
            var found = usersRepository.GetAll().Any(x => x.Username == user.Username);

            if (found)
                return BadRequest("There is already user with that name");

            usersRepository.Add(user);
            return Ok("User with name: " + username + " was successfully added");
        }

        [HttpPost]
        [Route("friend")]
        public IActionResult AddFriend([FromBody] AddFriendRequestModel addFriendRequestModel)
        {
            var firstUserId = new UserId(addFriendRequestModel.CurrentUserId);
            var secondUserId = new UserId(addFriendRequestModel.UserToBeAddedId);

            var firstUser = usersRepository.GetById(firstUserId);
            var secondUser = usersRepository.GetById(secondUserId);

            if (firstUser == null || secondUser == null)
                return NotFound("There are no users with such ids");

            Friendship friendship = new Friendship(firstUserId, secondUserId);

            bool found = friendshipsRepo.GetAll().Any(x => x == friendship);

            if (found)
                return BadRequest("The friendship that you are trying to create already exists");

            friendshipsRepo.Add(friendship);
            return Ok("Friendship successfully created");
        }
    }
}