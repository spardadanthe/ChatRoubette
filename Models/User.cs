using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class User
    {
        public User(string username)
        {
            if(!(string.IsNullOrEmpty(username))) Username = username;
        }

        

        public string Username { get; private set; }
        public List<User> Friends { get; set; }
        public List<Conversation> Current { get; set; }
    }
}
