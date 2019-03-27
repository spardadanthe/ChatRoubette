using System;
using System.Collections.Generic;

namespace Chatman
{
    public class Conversation : BaseEntity
    {
        public Conversation(ICollection<UserId> usersParticipatingIds)
            : this(new ConversationId(Guid.NewGuid().ToString()), usersParticipatingIds) { }

        public Conversation(ConversationId id, ICollection<UserId> usersParticipatingIds) : base(id)
        {
            if (usersParticipatingIds is null) throw new ArgumentNullException(nameof(usersParticipatingIds));
            if (usersParticipatingIds.Count <= 1) throw new ArgumentException("Conversation cannot be created with 1 or less users");

            UsersParticipatingIds = usersParticipatingIds;
            History = new List<Message>();
        }

        public ICollection<UserId> UsersParticipatingIds { get; private set; }
        public ICollection<Message> History { get; private set; }

        public bool AddMessage(Message message)
        {
            if (message is null) return false;

            History.Add(message);

            return true;

        }

        public bool AddParticipantToConversation(UserId participantId)
        {
            if (participantId is null) return false;

            UsersParticipatingIds.Add(participantId);

            return true;
        }

    }
}
