using Chatman.Persistence.EF.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Chatman.Persistence.EF.Dtos
{
    public class ConversationUser : IDtoId
    {
        [Key]
        public string Id { get; set; }

        public string ConversationId { get; set; }
        [ForeignKey("ConversationId")]
        public ConversationDto Conversation { get; set; }

        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public UserDto User { get; set; }
    }
}
