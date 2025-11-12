using CPR.API.Data;
using CPR.API.Data.Interfaces;
using CPR.API.Services;
using CPR.API.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace CPR.WebFunctions.Common
{
    public static class Extensions
    {
        public static IServiceCollection AddMyDependencies(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IAstuteService, AstuteService>();
            services.AddTransient<ILightstoneService, LightstoneService>();
            services.AddTransient<IClientService, ClientService>();
            services.AddTransient<IPropertyService, PropertyService>();
            services.AddTransient<IPolicyService, PolicyService>();
            services.AddTransient<IVehicleService, VehicleService>();
            services.AddTransient<IAstureRequestService, AstureRequestService>();
            services.AddTransient<IBrokerService, BrokerService>();
            services.AddTransient<IBrokerRequestService, BrokerRequestService>();
            return services;
        }
    }
}
