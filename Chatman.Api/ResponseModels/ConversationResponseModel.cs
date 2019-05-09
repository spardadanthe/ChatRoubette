using Chatman.Persistence.EF.Dtos;
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
                BlockedUsersIds = new List<string>();

                foreach (var userId in conversation.BlockedUsersIds)
                {
                    BlockedUsersIds.Add(userId.Value);
                }

                //BlockedUsersIds = conversation.BlockedUsersIds.Select(x => x.Value).ToList();
            }

            if (conversation.UsersParticipatingIds is null == false)
            {
                UsersParticipatingIds = new List<string>();
                foreach (var userId in conversation.UsersParticipatingIds)
                {
                    UsersParticipatingIds.Add(userId.Value);
                }
            }
        }

        public string Id { get; private set; }
        public string OwnerId { get; private set; }
        public List<string> BlockedUsersIds { get; private set; }
        public List<string> UsersParticipatingIds { get; private set; }
    }
}
