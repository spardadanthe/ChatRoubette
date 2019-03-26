using System.Collections.Generic;
using System.Linq;
using Chatman;
using Persistence.Services;

namespace InMemoryPersistence.Repositories
{
    public class InMemoryUserRepository : IRepository<User>
    {
        private readonly ICollection<User> users;

        public InMemoryUserRepository()
        {
            users = ChatData.Users;
        }

        public ICollection<User> GetAll()
        {
            return users;
        }

        public void Add(User user)
        {
            users.Add(user);
        }
    }
}
