using System;
using System.Collections.Generic;
using System.Text;

namespace Chatman
{
    public class User
    {
        public User(string username)
        {
            if (string.IsNullOrEmpty(username)) throw new ArgumentException("Username cannot  be null ot empty");
            Username = username;
        }

        public string Username { get; private set; } 
        public List<User> Friends { get; set; }
        public List<Conversation> Current { get; set; }

        public void SendMessage(IMessageHandler messageSender)
        {
            messageSender.Send();
        }

        public void AddFriend(User user)
        {
            Friends.Add(user);
        }
    }
}
