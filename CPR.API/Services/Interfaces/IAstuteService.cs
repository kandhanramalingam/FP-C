using AstuteServiceReference;
using CPR.API.Models;

namespace CPR.API.Services.Interfaces
{
    public interface IAstuteService
    {
        Task<Result<ProductSectorSet>> GetProductSector(string key);
        Task<Result<ProductSet>> GetProductSet(string key, string sectorCode);
        Task<Result<object>> GetPortfolio(string key, PortfolioPayload portfolioPayload);
        Task<CPR.API.Models.Result> RetrievePortfolios(string key, Guid msgId);
    }
}