using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Chatman;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Client.Controllers
{
    public class ConversationController : Controller
    {
        private static string id;

        private async  Task<Conversation> GetCurrentConv()
        {
            using ( var client = new HttpClient())
            {
                var content = await client.GetStringAsync("https://localhost:44385/api/Conversations/" + id);
                var jsonobject = JsonConvert.DeserializeObject<Conversation>(content);
                return jsonobject;
            }
        }

        [HttpGet]
        public ActionResult Index()
        {
            Task<Conversation> currentConv = GetCurrentConv();
            if (id is null)
                return RedirectToAction("Index","Home");
            return View(currentConv); 
        }
        
        public void GetId([FromBody] string convId)
        {
            id = convId;
         }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Conversation/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Conversation/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Conversation/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}