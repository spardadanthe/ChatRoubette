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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ConversationUser>()
                .HasKey(k => new { k.ConversationId, k.UserId });

            modelBuilder.Entity<ConversationUser>()
                .HasOne(conv => conv.Conversation)
                .WithMany(convUsers => convUsers.ConversationUsers)
                .HasForeignKey(convUsers => convUsers.ConversationId)
                .OnDelete(DeleteBehavior.SetNull);

            // user -> userConverastions restrict
            // userconversation -> user NoAction
            // userCOnversation -> Conversation NoAction
            // Conversation -> userConversation Cascade

            modelBuilder.Entity<ConversationUser>()
                .HasOne(convUser => convUser.User)
                .WithMany(user => user.ConversationUsers)
                .HasForeignKey(convUser => convUser.UserId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<ConversationBlockedUsers>()
                .HasKey(x => new { x.ConversationId, x.UserId });

            modelBuilder.Entity<ConversationBlockedUsers>()
                .HasOne(convBlUsers => convBlUsers.Conversation)
                .WithMany(convDto => convDto.ConversationBlockedUsers)
                .HasForeignKey(convBlUsers => convBlUsers.ConversationId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ConversationBlockedUsers>()
                .HasOne(convBlUsers => convBlUsers.User)
                .WithMany(userDto => userDto.ConversationBlockedUsers)
                .HasForeignKey(convBlUsers => convBlUsers.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
