using CPR.API.Models;
using CPR.API.Services.Interfaces;

namespace CPR.API.Services
{
    public class LightstoneService : ILightstoneService
    {
        public LightstoneService()
        {
            
        }

        public Task RetrievePropertyInfo(PortfolioPayload portfolio)
        {
            throw new NotImplementedException();
        }

        public Task RetrieveVehicleInfo(PortfolioPayload portfolio)
        {
            throw new NotImplementedException();
        }
    }
}
