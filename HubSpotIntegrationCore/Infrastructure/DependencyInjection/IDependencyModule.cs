using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HubSpotIntegrationCore.Infrastructure.DependencyInjection
{
    public interface IDependencyModule
    {
        void ConfigureServices(IServiceCollection services);
    }
}
