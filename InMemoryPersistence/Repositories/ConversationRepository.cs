using Chatman;
using Persistence.Services;
using System.Collections.Generic;

namespace InMemoryPersistence.Repositories
{
    public  class InMemoryConversationRepository : IRepository<Conversation>
    {
        private readonly ICollection<Conversation> Conversations;

        public InMemoryConversationRepository()
        {
            Conversations = ChatData.Conversations;
        }


        public ICollection<Conversation> GetAll()
        {
            return Conversations;
        }

        public void Add(Conversation conversation)
        {
            Conversations.Add(conversation);
        }
    }
}
