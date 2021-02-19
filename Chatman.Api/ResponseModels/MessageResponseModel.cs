using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chatman.Api.ResponseModels
{
    public class MessageResponseModel
    {
        public MessageResponseModel(Message message)
        {
            if (message is null) throw new ArgumentNullException(nameof(message));

            Id = message.Id.Value;
            SenderId = message.SenderId.Value;
            ConvId = message.ConvId.Value;
            Text = message.Text;
            Date = message.Date;
        }

        public string Id { get; set; }
        public string SenderId { get; private set; }
        public string ConvId { get; private set; }
        public string Text { get; private set; }
        public DateTime Date { get; private set; }
    }
}
