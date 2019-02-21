using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hanssens.Net;
using Models;

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

        //public User GetUser()
        //{
        //    var storage = new LocalStorage();


        //    using (storage)
        //    {
        //        User user;
        //        try
        //        {
        //        user = storage.Get<User>("user");
        //        }
        //        catch (Exception)
        //        {
        //        }
        //        return user;
        //    }

        //}
    }
}
