using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chatman.Api.ResponseModels
{
    public class FriendshipResponseModel
    {
        public FriendshipResponseModel(string firstUserId,string secondUserId)
        {
            FirstUserId = firstUserId;
            SecondUserId = secondUserId;
        }

        public string FirstUserId { get; set; }
        public string SecondUserId { get; set; }
    }
}
