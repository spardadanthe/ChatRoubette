using Chatman;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Models
{
    public class UserAndFriendsViewModel
    {
        public User User { get; private set; }
        public HashSet<User> Friends { get; private set; }
    }
}
