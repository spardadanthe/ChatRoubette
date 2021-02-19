using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chatman.Api.ResponseModels
{
    public class FriendshipResponseModel
    {
        public FriendshipResponseModel(Friendship friendship)
        {
            if(friendship is null) throw new ArgumentNullException(nameof(friendship));

            FirstUserId = friendship.FirstUserId.Value;
            SecondUserId = friendship.SecondUserId.Value;
        }

        public string FirstUserId { get; private set; }
        public string SecondUserId { get; private set; }
    }
}
