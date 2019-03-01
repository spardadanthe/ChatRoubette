using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Chatman;
using Client.Repositories;
using Hanssens.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers
{
    public class UserController : Controller
    {
        private IRepository<User> FriendRepo;
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

        public ActionResult AddToConversation(List<string> ids)
        {

            return View();
        }
    }
}