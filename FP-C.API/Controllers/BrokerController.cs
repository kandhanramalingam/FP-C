using FP_C.API.Common;
using FP_C.API.Data.Interfaces;
using FP_C.API.Models;
using FP_C.API.Models.DataEntities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FP_C.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiKeyAuth]
    public class BrokerController(IRepository<BrokerRequest> brService, IRepository<Broker> bService) : ControllerBase
    {
        private readonly IRepository<Broker> _bService = bService;
        private readonly IRepository<BrokerRequest> _brService = brService;
        private const string key = "api_key";

        [HttpPost("AddBroker")]
        public async Task<Result<Broker>> AddBroker([FromBody] BrokerPayload payload)
        {
            try
            {
                var brokers = _bService.Find(b => b.Code == payload.Code);
                if(brokers != null && brokers.Any())
                {
                    return Result<Broker>.Ok(brokers.FirstOrDefault(), "Broker already exists.");
                }

                var obj = payload.ToBroker();
                await _bService.AddAsync(obj);
                await _bService.SaveChanges();
                if (brokers == null || !brokers.Any())
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
                
                var brokers = _bService.GetAll();
                if (brokers == null || !brokers.Any())
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
                    var brokers = _bService.Find(b => b.ApiKey == potentialApiKey.ToString()).Include(x => x.BrokerRequests);
                    if (brokers == null || !brokers.Any())
                    {
                        return Result<IEnumerable<BrokerRequest>>.Fail("Broker not found for the provided API Key.");
                    }
                    var broker = brokers.FirstOrDefault();
                    #endregion GetBroker
                    return Result<IEnumerable<BrokerRequest>>.Ok(broker.BrokerRequests);
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
