using BrainStorm.Models.Interface;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tutorial.Controllers.Interface;

namespace BrainStorm.Areas.Identity.Services
{
    public static class ServiceExtensions
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IArticle, ArticleService>();

            // Add all other services here.
            return services;
        }
    }
}

