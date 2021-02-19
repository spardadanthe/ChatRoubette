using System.Linq;
using Chatman;
using Client.Repositories;
using Hanssens.Net;
using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers
{
    public class UserController : Controller
    {
        //private FriendsRepository FriendRepo;
        private ConversationRepository ConvRepo;
        // GET: User
        public ActionResult Index()
        {
            return View();
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