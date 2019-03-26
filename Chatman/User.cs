using System;
using System.Collections.Generic;

namespace Chatman
{
    public class User
    {
        public User(string username)
        {
            if (string.IsNullOrEmpty(username)) throw new ArgumentException(nameof(username));

            Id = new UserId(Guid.NewGuid().ToString());
            Username = username;
            FriendIds = new HashSet<UserId>();
        }

        public User(UserId userId,string username)
        {
            if (userId is null) throw new ArgumentNullException(nameof(userId));
            if (string.IsNullOrEmpty(username)) throw new ArgumentException(nameof(username));

            Id = userId;
            Username = username;
            FriendIds = new HashSet<UserId>();
        }

        public UserId Id { get; private set; }
        public string Username { get; private set; }
        public ICollection<UserId> FriendIds { get; private set; }

        public bool AddFriend(UserId friendId)
        {
            if (friendId is null) return false;

            FriendIds.Add(friendId);

            return true;
        }

    }
}
