using HubSpotIntegrationCore.Domain.Interfaces.Repository;
using HubSpotIntegrationCore.Domain.Interfaces.Services;
using HubSpotIntegrationCore.Domain.Repositories;
using HubSpotIntegrationCore.Domain.Services;
using HubSpotIntegrationCore.Infrastructure.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HubSpotIntegrationCore.Infrastructure.Modules
{
    public class ServicesModule : IDependencyModule
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IContactService, ContactService>();
            services.AddScoped<IContactRepository, ContactRepository>();
        } 
    }
}
