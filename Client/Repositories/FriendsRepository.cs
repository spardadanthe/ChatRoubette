using Chatman;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Client.Repositories
{
    public class FriendsRepository
    {
        //Not Used atm
        [HttpPost]
        public bool Add([FromBody] AddFriendRequest addFriendRequest)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response = client.PostAsJsonAsync("https://localhost:44385/api/Friends", addFriendRequest).Result;
                if (response.IsSuccessStatusCode) return true;
                return false;
            }

        }

        public User Get()
        {
            throw new NotImplementedException();
        }
    }
}
