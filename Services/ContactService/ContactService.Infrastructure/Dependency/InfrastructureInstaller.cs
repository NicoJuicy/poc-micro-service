using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactService.Infrastructure.Dependency
{
    public static class InfrastructureInstaller
    {

        public static void AddInfrastructure(this IServiceCollection services, string connectionString)
        {
            services.AddMarten(connectionString);
        }
    }
}
