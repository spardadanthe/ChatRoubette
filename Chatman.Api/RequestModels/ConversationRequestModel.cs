using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chatman.Api.RequestModels
{
    public class ConversationRequestModel
    {
        public ConversationRequestModel()
        {

        }

        public string Id { get; set; }
        public ICollection<string> UsersParticipatingIds { get; set; }
    }
}
    