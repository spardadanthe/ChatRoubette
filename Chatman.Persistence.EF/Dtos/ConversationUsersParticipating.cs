using Chatman.Persistence.EF.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Chatman.Persistence.EF.Dtos
{
    public class ConversationUsersParticipating 
    {
        [Key]
        public string Id { get; set; }
        public string ConversationId { get; set; }
        public ConversationDto Conversation { get; set; }

        public string UserId { get; set; }
        public UserDto User { get; set; }
    }
}
