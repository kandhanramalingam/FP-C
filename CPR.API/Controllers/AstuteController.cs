using AstuteServiceReference;
using CPR.API.Common;
using CPR.API.Models;
using CPR.API.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CPR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiKeyAuth]
    public class AstuteController(IAstuteService astuteService) : ControllerBase
    {
        private const string ApiKeyHeaderName = "api_key";
        private readonly IAstuteService _AstuteService = astuteService;

        [HttpGet("GetProductSector")]
        public async Task<Result<ProductSectorSet>> GetProductSector()
        {
            if (HttpContext.Request.Query.TryGetValue(ApiKeyHeaderName, out var potentialApiKey))
            {
                return await _AstuteService.GetProductSector(potentialApiKey);
            }
            return Result<ProductSectorSet>.Fail("Unauthorized");
        }

        [HttpGet("GetProductSet/{sectorCode}")]
        public async Task<Result<ProductSet>> GetProductSet(string sectorCode)
        {
            if (HttpContext.Request.Query.TryGetValue(ApiKeyHeaderName, out var potentialApiKey))
            {
                return await _AstuteService.GetProductSet(potentialApiKey, sectorCode);
            }
            return Result<ProductSet>.Fail("Unauthorized");
        }

        [HttpPost("GetPortfolio")]
        public async Task<Result<object>> GetPortfolio([FromBody] PortfolioPayload payload)
        {            
            if (HttpContext.Request.Query.TryGetValue(ApiKeyHeaderName, out var potentialApiKey))
            {
                return await _AstuteService.GetPortfolio(potentialApiKey, payload);
            }
            return Result<object>.Fail("Unauthorized");
        }
    }
}
