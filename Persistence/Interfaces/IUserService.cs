using Chatman;
using System.Collections.Generic;

namespace Persistence.Interfaces
{
    public interface IUserService
    {
        IEnumerable<User> GetAll();

        User GetById(UserId userId);

        User GetByUsername(string userName);

        IEnumerable<User> GetUserFriends(UserId id);

        bool AddFriend(User userToBeAdded, User currentUser);
    }
}
