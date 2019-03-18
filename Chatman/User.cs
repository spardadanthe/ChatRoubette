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
            Friends = new HashSet<UserId>();
            ConversationIds = new HashSet<ConversationId>();
        }

        public UserId Id { get; private set; }
        public string Username { get; private set; }
        public HashSet<UserId> Friends { get; private set; }
        public HashSet<ConversationId> ConversationIds { get; private set; }

        public void AddFriend(UserId userId)
        {
            if (userId is null) throw new ArgumentNullException(nameof(userId));

            Friends.Add(userId);
        }
    }
}
