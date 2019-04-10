using Microsoft.EntityFrameworkCore;
using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Design;
using Chatman.Persistence.EF.Dtos;

namespace Chatman.Persistence.EF
{
    public class ChatmanContext : DbContext
    {
        public ChatmanContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<UserDto> Users { get; set; }
        public DbSet<ConversationDto> Conversations { get; set; }
        public DbSet<FriendshipDto> Friendships { get; set; }
        public DbSet<MessageDto> Messages { get; set; }

        public DbSet<ConversationBlockedUsers> BlockedUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {



           
        }

    }
}
