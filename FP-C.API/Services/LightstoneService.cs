using FP_C.API.Models;
using FP_C.API.Services.Interfaces;
using Microsoft.Extensions.Configuration;

namespace FP_C.API.Services
{
    public class LightstoneService : ILightstoneService
    {
        private readonly IApiService _apiService;
        private readonly IConfiguration _configuration;

        public LightstoneService(IApiService apiService, IConfiguration configuration)
        {
            _apiService = apiService;
            _configuration = configuration;
        }

        public async Task RetrievePropertyInfo(PortfolioPayload portfolio)
        {
            //await _apiService.ExecuteAsync
        }

        public Task RetrieveVehicleInfo(PortfolioPayload portfolio)
        {
            throw new NotImplementedException();
        }
    }
}
