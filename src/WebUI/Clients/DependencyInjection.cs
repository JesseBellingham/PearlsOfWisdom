using System;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace PearlsOfWisdom.WebUI.Clients
{
    public static class DependencyInjection
    {
        private static string _baseUrl;
        
        public static IServiceCollection AddHttpClients(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            _baseUrl = configuration.GetSection("ApiBaseUrl")?.Value;
            services.AddHttpClient<IPearlsListClient, PearlsListClient>(ConfigureClient());
            services.AddHttpClient<IPearlItemClient, PearlItemClient>(ConfigureClient());
            services.AddHttpClient<IKeyPointClient, KeyPointClient>(ConfigureClient());
            return services;
        }

        private static Action<HttpClient> ConfigureClient()
        {
            return client => client.BaseAddress = new Uri(_baseUrl);
        }
    }
}