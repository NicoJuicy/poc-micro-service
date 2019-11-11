using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace NoteService.Infrastructure.Dependency
{
    public static class InfrastructureInstaller
    {
        public static void AddInfrastructure(this IServiceCollection services, string connectionString)
        {
            services.AddMarten(connectionString);
        }
    }
}
