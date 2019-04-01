using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chatman.Api.RequestModels
{
    public class MessageRequestModel
    {
        public MessageRequestModel()
        {

        }

        public string ConvId { get; set; }
        public string AuthorId { get; set; }
        public string Text { get; set; }

    }
}
