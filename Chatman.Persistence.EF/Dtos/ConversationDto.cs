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
        public UserDto Owner { get; set; }

        ICollection<UserDto> Users { get; set; }

        public ICollection<ConversationBlockedUsers> BlockedUsers { get; set; }
        public ICollection<ConversationUser> ConversationUsers{ get; set; }

    }
}
