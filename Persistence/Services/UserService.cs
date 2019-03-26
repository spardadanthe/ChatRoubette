using Chatman;
using Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Persistence.Services
{
    public class UserService : IUserService    {
        private readonly IRepository<User> repo;

        public UserService(IRepository<User> repo)
        {
            this.repo = repo;
        }

        public IEnumerable<User> GetAll()
        {
            return repo.GetAll();
        }

        public User GetById(UserId userId)
        {
            return repo.GetAll().FirstOrDefault(x => x.Id.Value == userId.Value);
        }

        public User GetByUsername(string userName)
        {
            return repo.GetAll().FirstOrDefault(x => x.Username == userName);
        }

        public IEnumerable<User> GetUserFriends(UserId userId)
        {
            var currentUser = repo.GetAll().FirstOrDefault(x => x.Id == userId);

            var listOfFriends = new List<User>();

            if (currentUser is null == false)
            {
                foreach (var friendId in currentUser.FriendIds)
                {
                    var friend = repo.GetAll().FirstOrDefault(x => x.Id.Value == friendId.Value);

                    if (friend is null == false)
                        listOfFriends.Add(friend);
                }
            }

            return listOfFriends;
        }

        public bool AddFriend(User userToBeAdded, User currentUser)
        {
            if (userToBeAdded == null || currentUser == null || userToBeAdded.FriendIds.Any(x => x.Value == currentUser.Id.Value))
            {
                return false;
            }

            userToBeAdded.AddFriend(currentUser.Id);
            currentUser.AddFriend(userToBeAdded.Id);

            SaveNew(userToBeAdded);
            SaveNew(currentUser);

            return true;
        }

        private void SaveNew(User user)
        {
            if (repo.GetAll().Any(x => x.Username.ToLower() == user.Username.ToLower()) == false)
                repo.Add(user);
        }
    }
}
