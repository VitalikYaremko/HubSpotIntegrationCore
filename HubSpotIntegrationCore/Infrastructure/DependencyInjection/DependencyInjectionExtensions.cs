using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HubSpotIntegrationCore.Infrastructure.DependencyInjection
{
    public static class DependencyInjectionExtensions
    {
        public static void AddModule<T>(this IServiceCollection services) where T : class, IDependencyModule, new()
        {
            new T().ConfigureServices(services);
        }
    }
}
