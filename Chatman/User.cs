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

            Id = new UserId(Guid.NewGuid().ToString());
            Username = username;
            Friends = new HashSet<User>();
            ConversationIds = new HashSet<ConversationId>();
        }

        public UserId Id { get; private set; }
        public string Username { get; private set; }
        public HashSet<User> Friends { get; private set; }
        public HashSet<ConversationId> ConversationIds { get; private set; }

        public void AddFriend(User user)
        {
            if (user is null) throw new ArgumentNullException(nameof(user));

            Friends.Add(user);
        }
    }
}
