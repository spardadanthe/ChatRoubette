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

        [ForeignKey("Owner")]
        public string OwnerId { get; set; }

        [Required]
        public UserDto Owner { get; set; }


        
        public ICollection<ConversationBlockedUsers> BlockedUsers { get; set; }
        public ICollection<ConversationUsersParticipating> UsersParticipating { get; set; }
        
    }
}
