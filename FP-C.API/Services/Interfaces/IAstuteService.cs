using AstuteServiceReference;
using FP_C.API.Models;

namespace FP_C.API.Services.Interfaces
{
    public interface IAstuteService
    {
        Task<Result<ProductSectorSet>> GetProductSector(string key);
        Task<Result<ProductSet>> GetProductSet(string key, string sectorCode);
        Task<Result<object>> GetPortfolio(string key, PortfolioPayload portfolioPayload);
        Task<FP_C.API.Models.Result> RetrievePortfolios(string key, Guid msgId);
        Task RunRetrieval();
    }
}