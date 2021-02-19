using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chatman.Api.ResponseModels
{
    public class UserResponseModel
    {
        public UserResponseModel(User user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));

            Id = user.Id.Value;
            Username = user.Username;
        }

        public string Id { get; set; }
        public string Username { get; set; }

    }
}
