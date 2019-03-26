using System.Collections.Generic;
using System.Linq;
using Chatman;
using Persistence.Interfaces;

namespace Persistence.Services
{
    public class ConversationService : IConversationService
    {
        private readonly IRepository<Conversation> repo;

        public ConversationService(IRepository<Conversation> repo)
        {
            this.repo = repo;
        }

        public ICollection<Conversation> GetAll()
        {
            return repo.GetAll();
        }

        public Conversation GetById(ConversationId convId)
        {
            return repo.GetAll().FirstOrDefault(x => x.Id == convId);
        }

        public void Add(Conversation convToBeAdded)
        {
            repo.Add(convToBeAdded);
        }
    }
}
