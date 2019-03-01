using Chatman;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Client.Repositories
{
    public class FriendsRepository : IRepository<User>
    {
        public bool Add(string name)
        {
            using (var client = new HttpClient())
            {
                User user = new User(name);
                HttpResponseMessage response = client.PostAsJsonAsync("https://localhost:44385/api/Friends",user).Result;
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
