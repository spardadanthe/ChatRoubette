﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Chatman.Persistence.EF.Dtos
{
    public class FriendshipDto : IDtoId
    {
        [Key]
        public string Id { get; set; }

        public string FirstUserId { get; set; }
        [ForeignKey("FirstUserId")]
        public virtual UserDto FirstUser { get; set; }

        public string SecondUserId { get; set; }

        [ForeignKey("SecondUserId")]
        public virtual UserDto SecondUser { get; set; }
    }
}
