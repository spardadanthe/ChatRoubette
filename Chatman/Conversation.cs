using System;
using System.Collections.Generic;
using System.Linq;

namespace Chatman
{
    public class Conversation : BaseEntity
    {
        [Obsolete("Serialization Use Only")]
        private Conversation(){ }
        public Conversation(ICollection<UserId> usersParticipatingIds,UserId ownerId)
            : this(new ConversationId(Guid.NewGuid().ToString()), usersParticipatingIds,ownerId) { }

        public Conversation(ConversationId id, ICollection<UserId> usersParticipatingIds,UserId ownerId,
            ICollection<Message> messages = null) : base(id)
        {
            if (usersParticipatingIds is null) throw new ArgumentNullException(nameof(usersParticipatingIds));
            if (usersParticipatingIds.Count <= 1) throw new ArgumentException("Conversation cannot be created with 1 or less users");
            if (ownerId is null) throw new ArgumentException(nameof(ownerId));

            UsersParticipatingIds = usersParticipatingIds;
            OwnerId = ownerId;

            if (messages is null == false)
            {
                History = messages;
            }
            else
            {
                History = new List<Message>();
            }

        }

        public UserId OwnerId { get; private set; }
        public ICollection<UserId> BlockedUsersIds { get; private set; }
        public ICollection<UserId> UsersParticipatingIds { get; private set; }
        public ICollection<Message> History { get; private set; }

        public bool AddMessage(Message message)
        {
            if (message is null) return false;

            History.Add(message);

            return true;

        }

        public void BlockUser(UserId userId)
        {
            if(userId is null) throw new ArgumentNullException(nameof(userId));

            if (string.IsNullOrEmpty(userId.Value))
                throw new ArgumentException(nameof(userId.Value) + "cannot be empty");

            if (userId == OwnerId)
                throw new ArgumentException("The owner of the conversation cannot block himself");

            if (BlockedUsersIds.Any(x => x.Value == userId.Value))
                throw new ArgumentException("There is already blocker user with this id");

            BlockedUsersIds.Add(userId);
        }

        public bool AddParticipantToConversation(UserId participantId)
        {
            if (participantId is null) return false;

            UsersParticipatingIds.Add(participantId);

            return true;
        }



    }
}
