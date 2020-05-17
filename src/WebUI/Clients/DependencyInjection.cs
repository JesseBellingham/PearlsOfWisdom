using System;
using System.Net.Http;
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
            services.AddHttpClient<IPearlsListClient, PearlsListClient>(ConfigureClient(configuration));
            services.AddHttpClient<IPearlItemClient, PearlItemClient>(ConfigureClient(configuration));
            return services;
        }

        private static Action<HttpClient> ConfigureClient(IConfiguration configuration)
        {
            var baseUrl = configuration.GetSection("ApiBaseUrl")?.Value;
            return client => client.BaseAddress = new Uri(baseUrl);
        }
    }
}