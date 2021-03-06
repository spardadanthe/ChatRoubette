﻿using AutoMapper;
using Chatman.Persistence.EF;
using Chatman.Persistence.EF.Dtos;
using Chatman.Persistence.EF.Repositories;
using InMemoryPersistence.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Interfaces;

namespace Chatman.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("ChatPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });

            services.AddChatmanEfPersistence();
          
            services.AddEntityFrameworkSqlServer()

                 
                .AddDbContext<ChatmanContext>(options =>
                {
                    options.UseSqlServer(
                        "Data Source=localhost;Initial Catalog=Test;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False",
                        sqlOptions => sqlOptions.MigrationsAssembly(typeof(Startup).Assembly.GetName().Name));
                }, ServiceLifetime.Transient);

            //services.SetupDatabase("Data Source=localhost;Initial Catalog=Test;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False",typeof(Startup).GetType().Assembly);

            services.AddTransient<IRepository<User>, EfRepository<User,UserDto>>();
            services.AddTransient<IRepository<Conversation>, EfRepository<Conversation, ConversationDto>>();
            services.AddTransient<IRepository<Friendship>, EfRepository<Friendship, FriendshipDto>>();
            services.AddTransient<IRepository<Message>, EfRepository<Message, MessageDto>>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseCors("ChatPolicy");
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
