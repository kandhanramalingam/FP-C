using FP_C.API.Common;
using FP_C.API.Models;
using FP_C.API.Models.DataEntities;
using FP_C.API.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FP_C.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiKeyAuth]
    public class ClientController(IClientService clientService) : ControllerBase
    {
        private readonly IClientService _ClientService = clientService;

        [HttpGet("GetClient/{clientId}")]
        public async Task<Result<ClientInfo>> GetClient(int clientId)
        {
            return Result<ClientInfo>.Ok((await _ClientService.FindAsync(c => c.Id == clientId))?.FirstOrDefault());
        }

        [HttpPost("AddClient")]
        public async Task<Result> AddClient(ClientInfo client)
        {
            await _ClientService.AddAsync(client);
            return Result.Ok("Success");
        }
    }
}
