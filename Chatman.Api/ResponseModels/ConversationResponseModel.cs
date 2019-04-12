using System.Collections.Generic;
using System.Linq;

namespace Chatman.Api.ResponseModels
{
    public class ConversationResponseModel
    {
        public ConversationResponseModel(string id,string ownerId,
            IEnumerable<string> blockedUsersIds, IEnumerable<string> usersparticipatingIds)
        {
            Id = id;
            OwnerId = ownerId;
            BlockedUsersIds = blockedUsersIds;
            UsersParticipatingIds = usersparticipatingIds;
        }

        public string Id { get; private set; }
        public string OwnerId { get; private set; }
        public IEnumerable<string> BlockedUsersIds { get; private set; }
        public IEnumerable<string> UsersParticipatingIds { get; private set; }
    }
}
