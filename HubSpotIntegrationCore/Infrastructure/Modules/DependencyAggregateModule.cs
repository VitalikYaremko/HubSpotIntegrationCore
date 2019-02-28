using HubSpotIntegrationCore.Infrastructure.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HubSpotIntegrationCore.Infrastructure.Modules
{
    public class DependencyAggregateModule : IDependencyModule
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddModule<ServicesModule>();
        }
    }
}
