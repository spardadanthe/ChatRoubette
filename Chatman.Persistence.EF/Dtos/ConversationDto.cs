using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Chatman.Persistence.EF.Dtos
{
    public class ConversationDto : IDtoId
    {
        [Key]
        public string Id { get; set; }

        [Required]
        public string OwnerId { get; set; }

        [Required]
        [ForeignKey("OwnerId")]
        public UserDto Owner { get; set; }

        //public ICollection<UserDto> Users { get; set; }
        public ICollection<MessageDto> Messages { get; set; }

        public ICollection<ConversationBlockedUsers> BlockedUsers { get; set; }
        public ICollection<ConversationUser> ConversationUsers{ get; set; }

    }
}
