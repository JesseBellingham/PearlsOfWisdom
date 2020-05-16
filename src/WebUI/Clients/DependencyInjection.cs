using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace PearlsOfWisdom.WebUI.Clients
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddHttpClients(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var baseUrl = configuration.GetSection("ApiBaseUrl")?.Value;
            services.AddHttpClient<IPearlsListClient, PearlsListClient>(client => client.BaseAddress = new Uri(baseUrl));
            return services;
        }
    }
}