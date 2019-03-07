using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Client.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Session;
using Hanssens.Net;
using Chatman;

namespace Client.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            User currentUser = null;
            UserStorage storage = new UserStorage();

            try
            {
                currentUser = storage.GetCurrentUser();
            }
            catch (Exception)
            {
            }
            if(!(string.IsNullOrEmpty(currentUser.Username)))
            {
            return RedirectToAction("Index", "User");
            }
            return View();

        }

        [HttpPost]
        public IActionResult Enter(string username)
        {
            UserStorage storage = new UserStorage();
            storage.SaveUser(username);
            return RedirectToAction("Index", "User");
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
