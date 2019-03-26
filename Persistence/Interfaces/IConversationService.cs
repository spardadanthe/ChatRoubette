using Chatman;
using System.Collections.Generic;

namespace Persistence.Interfaces
{
    public interface IConversationService
    {
        ICollection<Conversation> GetAll();

        Conversation GetById(ConversationId convId);

        void Add(Conversation convToBeAdded);

    }
}
