using AstuteServiceReference;
using FP_C.API.Data;
using FP_C.API.Data.Interfaces;
using FP_C.API.Models;
using FP_C.API.Models.DataEntities;
using FP_C.API.Services;
using FP_C.API.Services.Interfaces;

namespace FP_C.API.Common
{
    public static class Extensions
    {
        public static CcpRequestDetails GetPortfolio(this PortfolioPayload value)
        {
            CcpRequestDetails request = new();
            if(value != null)
            {
                request.IdNumber = value.IdNumber;
                request.IdType = IdType.SouthAfrican;
                request.Surname = value.Surname;
                request.Initials = value.Initials;
                request.DateOfBirth = MyCommon.GetDOB(value.IdNumber);
                request.CellNumber = value.CellNumber;
                request.EmailAddress = value.Email;
                request.OverrideDigitalConsent = true;
                request.RequestDetails = MyCommon.GetAllProviders();
            }
            return request;
        }

        public static ClientInfo ToClient(this PortfolioPayload value)
        {
            ClientInfo client = new();
            if(value != null)
            {
                client.IdNumber = value.IdNumber;
                client.Surname = value.Surname;
                client.Initials = value.Initials;
                client.DOB = MyCommon.GetDOB(value.IdNumber);
                client.PhoneNumber = value.CellNumber;
                client.Email = value.Email;
                client.Properties = [];
            }
            return client;
        }

        public static Broker ToBroker(this BrokerPayload value)
        {
            Broker broker = new();
            if(value != null)
            {
                broker.Name = value.Name;
                broker.Code = value.Code;
                broker.FSNumber = value.FSNumber;
                broker.ApiKey = Guid.NewGuid().ToString();
            }
            return broker;
        }

        public static IServiceCollection AddMyDependencies(this IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddScoped<IMemoryCacheService, MemoryCacheService>();
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
