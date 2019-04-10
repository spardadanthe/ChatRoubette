using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Chatman.Persistence.EF.Dtos
{
    public class UserDto : IDtoId
    {
        
        [Key]
        public string Id { get; set; }

        [Required]
        public string Username { get; set; }

        public ConversationDto Conversation { get; set; }
        public ICollection<ConversationBlockedUsers> BlockedUsers { get; set; }
    }

    
}
