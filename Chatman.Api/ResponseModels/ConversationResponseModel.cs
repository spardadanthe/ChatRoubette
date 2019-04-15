using System;
using System.Collections.Generic;
using System.Linq;

namespace Chatman.Api.ResponseModels
{
    public class ConversationResponseModel
    {
        public ConversationResponseModel(Conversation conversation)
        {
            if (conversation is null) throw new ArgumentNullException(nameof(conversation));

            Id = conversation.Id.Value;
            OwnerId = conversation.OwnerId.Value;

            if (conversation.BlockedUsersIds is null == false)
            {
                BlockedUsersIds = conversation.BlockedUsersIds.Select(x => x.Value);
            }

            if (conversation.UsersParticipatingIds is null == false)
            {
                UsersParticipatingIds = conversation.BlockedUsersIds.Select(x => x.Value);
            }
        }

        public string Id { get; private set; }
        public string OwnerId { get; private set; }
        public IEnumerable<string> BlockedUsersIds { get; private set; }
        public IEnumerable<string> UsersParticipatingIds { get; private set; }
    }
}
