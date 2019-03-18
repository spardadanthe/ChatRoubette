using System.Collections.Generic;
using System.Linq;
using Chatman;

namespace ChatApi.Controllers
{
    public static class UserProvider
    {
        private static HashSet<User> Users = new HashSet<User>();

        public static HashSet<User> GetAllUsers()
        {
            return Users;
        }

        public static IEnumerable<User> GetUserFriends(string userName)
        {
            var currentUser = Users.FirstOrDefault(x => x.Username == userName);

            var listOfFriends = new List<User>();

            if(currentUser is null == false)
            {
                foreach (var friendId in currentUser.Friends)
                {
                    var friend = Users.FirstOrDefault(x => x.Id.Value == friendId.Value);

                    if (friend is null == false)
                        listOfFriends.Add(friend);
                }
            }
            
            return listOfFriends;
        }

        public static User GetUserByUsername(string userName)
        {
            return Users.FirstOrDefault(x => x.Username == userName);
        }

        public static User GetUserById(UserId userId)
        {
            return Users.FirstOrDefault(x => x.Id.Value == userId.Value);
        }

        public static void SaveUser(User user)
        {
            try
            {
                Users.RemoveWhere(x => x.Id.Value == user.Id.Value);
            }
            catch (System.Exception)
            {
            }
            finally
             {
                Users.Add(user);
            }
        }
    }
}
