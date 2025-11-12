using FP_C.API.Models;

namespace FP_C.API.Services.Interfaces
{
    public interface ILightstoneService
    {
        Task RetrievePropertyInfo(PortfolioPayload portfolio);
        Task RetrieveVehicleInfo(PortfolioPayload portfolio);
    }
}
