using BrainStorm.Models.Interface;
using Microsoft.Extensions.DependencyInjection;

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

