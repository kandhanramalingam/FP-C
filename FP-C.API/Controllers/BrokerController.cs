using FP_C.API.Common;
using FP_C.API.Models;
using FP_C.API.Models.DataEntities;
using FP_C.API.Services;
using FP_C.API.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace FP_C.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiKeyAuth]
    public class BrokerController(IBrokerService brokerService, IBrokerRequestService brokerRequestService) : ControllerBase
    {
        private readonly IBrokerService _brokerService = brokerService;
        private readonly IBrokerRequestService _brokerRequestService = brokerRequestService;
        private const string key = "api_key";

        [HttpPost("AddBroker")]
        public async Task<Result<Broker>> AddBroker([FromBody] BrokerPayload payload)
        {
            try
            {
                var brokers = await _brokerService.FindAsync(b => b.Code == payload.Code);
                if(brokers != null && brokers.Any())
                {
                    return Result<Broker>.Ok(brokers.FirstOrDefault(), "Broker already exists.");
                }

                var obj = payload.ToBroker();
                await _brokerService.AddAsync(obj);
                if(brokers == null || !brokers.Any())
                {
                    return Result<Broker>.Fail("Broker not found after addition.");
                }
                return Result<Broker>.Ok(brokers.FirstOrDefault());
            }
            catch (Exception ex)
            {
                return Result<Broker>.Fail(ex.Message);
            }
        }

        [HttpGet("GetAll")]
        public async Task<Result<IEnumerable<Broker>>> GetAll()
        {
            try
            {
                var brokers = await _brokerService.GetAllAsync();
                if(brokers == null || !brokers.Any())
                {
                    return Result<IEnumerable<Broker>>.Fail("No brokers found.");
                }
                return Result<IEnumerable<Broker>>.Ok(brokers);
            }
            catch (Exception ex)
            {
                return Result<IEnumerable<Broker>>.Fail(ex.Message);
            }
        }

        [HttpGet("GetAllBrokerRequests")]
        public async Task<Result<IEnumerable<BrokerRequest>>> GetAllBrokerRequest()
        {
            try
            {
                if (HttpContext.Request.Query.TryGetValue(key, out var potentialApiKey))
                {
                    #region GetBroker
                    if (string.IsNullOrEmpty(potentialApiKey))
                    {
                        return Result<IEnumerable<BrokerRequest>>.Fail("API Key is required.");
                    }
                    var brokers = await _brokerService.FindAsync(x => x.ApiKey == potentialApiKey);
                    if (brokers == null || !brokers.Any())
                    {
                        return Result<IEnumerable<BrokerRequest>>.Fail("Broker not found for the provided API Key.");
                    }
                    var broker = brokers.FirstOrDefault();
                    #endregion GetBroker
                    return Result<IEnumerable<BrokerRequest>>.Ok(await _brokerRequestService.FindAsync(b => b.BrokerId == broker.Id));
                }
                return Result<IEnumerable<BrokerRequest>>.Fail("API Key is missing from the request.");
            }
            catch (Exception ex)
            {
                return Result<IEnumerable<BrokerRequest>>.Fail(ex.Message);
            }
        }
    }
}
