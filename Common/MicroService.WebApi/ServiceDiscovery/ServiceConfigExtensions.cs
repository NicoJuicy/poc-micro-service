using System;
using Microsoft.Extensions.Configuration;

namespace MicroService.WebApi.ServiceDiscovery
{
    public static class ServiceConfigExtensions
    {
        public static ServiceConfig GetServiceConfig(this IConfiguration configuration)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            var serviceConfig = new ServiceConfig
            {
                ServiceDiscoveryAddress = new Uri(configuration.GetSection("ServiceConfig:serviceDiscoveryAddress").Value),
                ServiceAddress = new Uri(configuration.GetSection("ServiceConfig:serviceAddress").Value),
                ServiceName = configuration.GetSection("ServiceConfig:serviceName").Value,
                ServiceId = configuration.GetSection("ServiceConfig:serviceId").Value
            };

            return serviceConfig;
        }
    }
}
