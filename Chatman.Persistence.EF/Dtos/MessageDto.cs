using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Chatman.Persistence.EF.Dtos
{
    public class MessageDto : IDtoId
    {
        public string Id { get; set; }
        public string SenderId { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }

        public ConversationDto Conversation { get; set; }

    }
}
