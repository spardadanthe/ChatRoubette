using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;

namespace Chatman.Persistence.EF
{
    public static class EfConfigurationsExtensions
    {
        public static IServiceCollection AddChatmanEfPersistence(this IServiceCollection services)
        {
            services.AddAutoMapper();
            return services;
        }

    }
}
