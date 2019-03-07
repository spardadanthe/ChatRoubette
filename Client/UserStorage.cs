using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hanssens.Net;
using Chatman;

namespace Client
{
    public class UserStorage
    {
        public void SaveUser(string username)
        {
            var storage = new LocalStorage();
            User user = new User(username);

            using (storage)
            {
                storage.Store("user", user);
            }
        }

        public User GetCurrentUser()
        {
            var storage = new LocalStorage();
            User user;

            using (storage)
            {
                    user = storage.Get<User>("user");
                    return user;
            }
        }
    }
}
