using Microsoft.EntityFrameworkCore;
using Chatman;
using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Design;

namespace Chatman.Persistence.EF
{
    public class ChatmanContext : DbContext
    {
        public ChatmanContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Conversation> Conversations { get; set; }
        public DbSet<Friendship> Friendships { get; set; }
        public DbSet<Message> Messages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var userEntity = modelBuilder.Entity<User>();
            var conversationEntity = modelBuilder.Entity<Conversation>();
            var friendshipEntity = modelBuilder.Entity<Friendship>();
            var messageEntity = modelBuilder.Entity<Message>();



            userEntity.HasKey(x => x.Id);
            userEntity.Property(p => p.Username).IsRequired();
            userEntity.Property(user => user.Id).HasConversion(
                v => v.ToString(),
                v => new UserId(v));


            //conversationEntity.HasKey("Id");
            //conversationEntity.Property(conv => conv.Id).HasColumnName("Id").HasConversion(
            //    v => v.ToString(),
            //    v => new BaseId(v));

            //conversationEntity.Property(p => p.UsersParticipatingIds).HasColumnType("varchar(max)");
            //conversationEntity.Property(conv => conv.Id).HasConversion(
            //    v => v.ToString(),
            //    v => new BaseId(v));

            //conversationEntity.Property(conv => conv.UsersParticipatingIds).HasConversion(
            //    v => JsonConvert.SerializeObject(v),
            //    v => JsonConvert.DeserializeObject<ICollection<UserId>>(v)
            //    );

            modelBuilder.Entity<Friendship>(f =>
            {
                f.HasKey(x => x.Id);
                f.Property(x => x.FirstUserId).IsRequired();
                f.Property(p => p.SecondUserId).IsRequired();

                f.Property(x => x.Id).HasConversion(
                    v => v.ToString(),
                    v => new FriendshipId(v));

                f.Property(x => x.FirstUserId).HasConversion(
                    v => v.ToString(),
                    v => new UserId(v));

                f.Property(x => x.SecondUserId).HasConversion(
                    v => v.ToString(),
                    v => new UserId(v));

                f.HasOne<UserId>().WithMany().HasForeignKey(x => x.FirstUserId).IsRequired();
                f.HasOne<UserId>().WithMany().HasForeignKey(x => x.SecondUserId).IsRequired();

                f.ToTable("Friendships");
            });



            //messageEntity.HasKey("Id");
            //messageEntity.Property(message => message.Id).HasConversion(
            //    v => v.ToString(),
            //    v => new BaseId(v));

            //messageEntity.Property(message => message.SenderId).HasColumnType("varchar(max)");
            //messageEntity.Property(message => message.SenderId).IsRequired();
            //messageEntity.Property(message => message.SenderId).HasConversion(
            //    v => v.ToString(),
            //    v => new UserId(v));

            //messageEntity.Property(message => message.Text).IsRequired();
            //messageEntity.Property(message => message.ConvId).HasConversion(
            //    v => v.ToString(),
            //    v => new ConversationId(v));
            //messageEntity.Property(message => message.ConvId).IsRequired();



            modelBuilder.Ignore<BaseId>();
            modelBuilder.Ignore<BaseEntity>();
            modelBuilder.Ignore<UserId>();
            modelBuilder.Ignore<ConversationId>();
            modelBuilder.Ignore<FriendshipId>();
            modelBuilder.Ignore<Conversation>();
            modelBuilder.Ignore<Message>();
        }

    }
}
