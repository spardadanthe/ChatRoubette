using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chatman.Api.RequestModels
{
    public class FriendshipRequestModel
    {
        public UserId FirstUserId { get; set; }
        public UserId SecondUserId { get; set; }
    }
}
