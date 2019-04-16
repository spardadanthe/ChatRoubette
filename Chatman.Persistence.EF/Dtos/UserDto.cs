using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Chatman.Persistence.EF.Dtos
{
    public class UserDto : IDtoId
    {
        public UserDto()
        {
        }


        [Key]
        [Column("Id", TypeName = "nvarchar(100)")]
        public string Id { get; set; }

        [Required]
        public string Username { get; set; }

        public ICollection<ConversationDto> Conversations { get; set; }
        public ICollection<ConversationUser> ConversationUsers { get; set; }
        public ICollection<ConversationBlockedUsers> BlockedUsers { get; set; }
    }

    
}
