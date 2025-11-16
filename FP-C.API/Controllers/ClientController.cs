using FP_C.API.Common;
using FP_C.API.Data.Interfaces;
using FP_C.API.Models;
using FP_C.API.Models.DataEntities;
using FP_C.API.Services;
using FP_C.API.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FP_C.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiKeyAuth]
    public class ClientController(IRepository<ClientInfo> cService) : ControllerBase
    {
        private readonly IRepository<ClientInfo> _cService = cService;

        [HttpGet("GetClient/{clientId}")]
        public async Task<Result<ClientInfo>> GetClient(int clientId)
        {
            var clients = _cService.Find(c => c.Id == clientId).Include(x => x.Policies).Include(x => x.Properties).Include(x => x.Vehicles);
            return Result<ClientInfo>.Ok(await clients.FirstOrDefaultAsync());
        }

        [HttpPost("AddClient")]
        public async Task<Result> AddClient(ClientInfo client)
        {
            await _cService .AddAsync(client);
            return Result.Ok("Success");
        }
    }
}
