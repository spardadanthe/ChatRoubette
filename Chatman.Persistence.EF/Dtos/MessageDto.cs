using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Chatman.Persistence.EF.Dtos
{
    public class MessageDto : IDtoId
    {
        [Key]
        public string Id { get; set; }


        [Required]
        public string SenderId { get; set; }

        [ForeignKey("SenderId")]
        public UserDto Sender { get; set; }

        [Required]
        public string Text { get; set; }

        public DateTime Date { get; set; }

        [Required]
        public string ConversationId { get; set; }

        [ForeignKey("ConversationId")]
        public ConversationDto Conversation { get; set; }

    }
}
