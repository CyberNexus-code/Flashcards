using Flashcards.Repositories;
using Flashcards.Services;
using Flashcards.UI;
using Microsoft.Extensions.DependencyInjection;

namespace Flashcards.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddCustomServices(this IServiceCollection services)
        {
            services.AddScoped<FlashcardRepository>();
            services.AddTransient<MainMenu>();
            services.AddTransient<StackMenu>();
            services.AddTransient<FlashcardMenu>();
            services.AddScoped<FlashcardService>();

            return services;
        }
    }
}
