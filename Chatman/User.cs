using System;
using System.Collections.Generic;

namespace Chatman
{
    public class User : BaseEntity
    {
        public User(string username) : base(new UserId(Guid.NewGuid().ToString()))
        {
            if (string.IsNullOrEmpty(username)) throw new ArgumentException(nameof(username));

            Username = username;
            FriendIds = new HashSet<UserId>();
        }

        public User(UserId userId,string username) : base(userId)
        {
            if (string.IsNullOrEmpty(username)) throw new ArgumentException(nameof(username));

            Username = username;
            FriendIds = new HashSet<UserId>();
        }

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
