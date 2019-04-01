using Microsoft.EntityFrameworkCore;
using Chatman;
using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Chatman.Persistence.EF
{
    public class ChatmanContext : DbContext
    {
        private readonly string connectionString;

        public ChatmanContext(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Conversation> Conversations { get; set; }
        public DbSet<Friendship> Friendships { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var userEntity = modelBuilder.Entity<User>();
            var conversationEntity = modelBuilder.Entity<Conversation>();
            var friendshipEntity = modelBuilder.Entity<Friendship>();
            var messageEntity = modelBuilder.Entity<Message>();



            userEntity.HasKey("Id");
            userEntity.Property(p => p.Username).IsRequired();
            userEntity.Property(user => user.Id).HasConversion(
                v => v.ToString(),
                v => new BaseId(v));


            conversationEntity.HasKey("Id");
            conversationEntity.Property(conv => conv.Id).HasColumnName("Id").HasConversion(
                v => v.ToString(),
                v => new BaseId(v));

            conversationEntity.Property(p => p.UsersParticipatingIds).HasColumnType("varchar(max)");
            conversationEntity.Property(conv => conv.Id).HasConversion(
                v => v.ToString(),
                v => new BaseId(v));

            conversationEntity.Property(conv => conv.UsersParticipatingIds).HasConversion(
                v => JsonConvert.SerializeObject(v),
                v => JsonConvert.DeserializeObject<ICollection<UserId>>(v)
                );

            friendshipEntity.HasKey("Id");
            friendshipEntity.ToTable("Friendship");
            friendshipEntity.Property(p => p.FirstUserId).IsRequired();
            friendshipEntity.Property(p => p.SecondUserId).IsRequired();

            friendshipEntity.Property(friendship => friendship.Id).HasConversion(
                v => v.ToString(),
                v => new FriendshipId(v));

            friendshipEntity.Property(friendship => friendship.FirstUserId).HasConversion(
                v => v.ToString(),
                v => new UserId(v));

            friendshipEntity.Property(friendship => friendship.SecondUserId).HasConversion(
                v => v.ToString(),
                v => new UserId(v));

            messageEntity.HasKey("Id");
            messageEntity.Property(message => message.Id).HasConversion(
                v => v.ToString(),
                v => new BaseId(v));

            messageEntity.Property(message => message.SenderId).HasColumnType("varchar(max)");
            messageEntity.Property(message => message.SenderId).HasConversion(
                v => v.ToString(),
                v => new UserId(v));

            modelBuilder.Ignore<BaseId>();
            modelBuilder.Ignore<BaseEntity>();
            modelBuilder.Ignore<UserId>();
            modelBuilder.Ignore<ConversationId>();
            modelBuilder.Ignore<FriendshipId>();
        }

    }
}
