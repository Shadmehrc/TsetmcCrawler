using Application.Services.Service;
using Application.Services.ServiceInterface;
using Infrastructure.DAL.RepositoryInterface;
using Infrastructure.DAL.RepositoryService;

namespace TsetmcCrawler.Configuration.DependecyInjection
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<ICrawlerService, CrawlerService>();
            services.AddScoped<ITsetmcCrawlerDAL, TsetmcCrawlerDAL>();
            services.AddScoped<ISignalRHub, SignalRHub>();
            services.AddScoped<IRabbitHub, RabbitHub>();
            return services;
        }
    }
}
