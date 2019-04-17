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
        [Column("Id", TypeName = "nvarchar(100)")]
        public string Id { get; set; }

        [Required]
        public string OwnerId { get; set; }

        [Required]
        [ForeignKey("OwnerId")]
        public UserDto Owner { get; set; }

        public IEnumerable<MessageDto> Messages { get; set; }

        public IEnumerable<ConversationBlockedUsers> ConversationBlockedUsers { get; set; }
        public IEnumerable<ConversationUser> ConversationUsers{ get; set; }

    }
}
