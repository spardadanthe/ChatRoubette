using System.Linq;
using Chatman;
using Client.Repositories;
using Hanssens.Net;
using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers
{
    public class UserController : Controller
    {
        private FriendsRepository FriendRepo;
        private ConversationRepository ConvRepo;
        // GET: User
        public ActionResult Index()
        {
            LocalStorage storage = new LocalStorage();
            User user = storage.Get<User>("user");
            return View(user);
        }

        public ActionResult AddFriend(string friendName)
        {
            FriendRepo = new FriendsRepository();
            FriendRepo.Add(friendName);
            return RedirectToAction("Index","User");
        }

        [HttpPost]
        public void AddToConversation([FromBody] AddToConversationRequestModel model)
        {
            ConvRepo = new ConversationRepository();
            var userIds = model.Ids.Select(x => new UserId(x)).ToHashSet();
            ConvRepo.Add(userIds);
        }
    }
}