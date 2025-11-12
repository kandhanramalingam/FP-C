using CPR.API.Models;

namespace CPR.API.Services.Interfaces
{
    public interface ILightstoneService
    {
        Task RetrievePropertyInfo(PortfolioPayload portfolio);
        Task RetrieveVehicleInfo(PortfolioPayload portfolio);
    }
}
