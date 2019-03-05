using System;
using System.Collections.Generic;

namespace Chatman
{
    public class Conversation
    {
        public Conversation(HashSet<UserId> usersParticipatingId)
        {
            UsersParticipatingId = usersParticipatingId;
            History = new List<Message>();
            Id = new ConversationId(Guid.NewGuid().ToString());
        }

        public ConversationId Id { get; private set; }
        public HashSet<UserId> UsersParticipatingId { get; private set; }
        public List<Message>  History { get; private set; }

        public void AddMessage(Message message)
        {
            if (message is null) throw new ArgumentNullException(nameof(message));
            History.Add(message);
        }
    }
}