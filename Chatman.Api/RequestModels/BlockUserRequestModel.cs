using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chatman.Api.RequestModels
{
    public class BlockUserRequestModel
    {
        public string ConvId { get; set; }
        public string UserId { get; set; }
    }
}
