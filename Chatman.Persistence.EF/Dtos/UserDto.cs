using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Chatman.Persistence.EF.Dtos
{
    public class UserDto : IDtoId
    {
        public UserDto()
        {
        }


        [Key]
        public string Id { get; set; }

        [Required]
        public string Username { get; set; }

        public ICollection<ConversationDto> Conversations { get; set; }

        //public ConversationDto Conversation { get; set; }
        public ICollection<ConversationUser> ConversationUsers { get; set; }
        public ICollection<ConversationBlockedUsers> BlockedUsers { get; set; }
    }

    
}
