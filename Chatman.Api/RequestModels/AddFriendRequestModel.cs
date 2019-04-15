using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chatman.Api.Controllers
{
    public class AddFriendRequestModel
    {
        public AddFriendRequestModel()
        {
        }

        public string CurrentUserId { get; set; }
        public string UserToBeAddedId { get; set; }
    }
}
