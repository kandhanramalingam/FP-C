using AstuteServiceReference;
using FP_C.API.Common;
using FP_C.API.Models;
using FP_C.API.Models.DataEntities;
using FP_C.API.Services.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace FP_C.API.Services
{
    public class AstuteService : IAstuteService
    {
        private readonly IConfiguration _configuration;
        private readonly IAstureRequestService _astureRequestService;
        private readonly IClientService _clientService;
        private readonly IBrokerRequestService _brokerRequestService;
        IBrokerService _brokerService;
        private readonly string _username;
        private readonly string _password;
        private readonly string _defaultUserAgent;
        private readonly AstuteServiceV3Client _client;

        public AstuteService(IConfiguration configuration
            , IAstureRequestService astureRequestService
            , IClientService clientService
            , IBrokerService brokerService
            , IBrokerRequestService brokerRequestService)
        {
            _configuration = configuration;
            _astureRequestService = astureRequestService;
            _clientService = clientService;
            _brokerService = brokerService;
            _brokerRequestService = brokerRequestService;
            var astuteSettings = _configuration.GetSection("Astute");
            _username = astuteSettings!["Username"];
            _password = astuteSettings!["Password"];
            _defaultUserAgent = astuteSettings!["UserAgent"];
            _client = new AstuteServiceV3Client();
            _client.ClientCredentials.UserName.UserName = _username;
            _client.ClientCredentials.UserName.Password = _password;
        }

        public async Task<Result<object>> GetPortfolio(string key, PortfolioPayload portfolioPayload)
        {
            Guid msgId = Guid.NewGuid();
            var item = portfolioPayload.GetPortfolio();

            #region GetBroker
            if (string.IsNullOrEmpty(key))
            {
                return Result<object>.Fail("Key cant be empty.");
            }
            var brokers = await _brokerService.FindAsync(x => x.ApiKey == key);
            if(brokers == null || !brokers.Any())
            {
                 return Result<object>.Fail("Invalid API Key.");
            }
            var broker = brokers.FirstOrDefault();
            #endregion GetBroker

            #region CreateGetClient
            var clients = await _clientService.FindAsync(x => x.IdNumber == portfolioPayload.IdNumber);
            ClientInfo client = null;
            if (clients == null || !clients.Any())
            {
                client = portfolioPayload.ToClient();
                await _clientService.AddAsync(client);
                clients = await _clientService.FindAsync(x => x.IdNumber == portfolioPayload.IdNumber);
            }
            client = clients.FirstOrDefault();
            #endregion CreateGetClient

            #region CCPRequest
            using OperationContextScope scope = new(_client.InnerChannel);
            HttpRequestMessageProperty p = new();
            p.Headers.Add(System.Net.HttpRequestHeader.UserAgent, broker.Code);
            OperationContext.Current.OutgoingMessageProperties.Add(HttpRequestMessageProperty.Name, p);
            var result = await _client.PerformCcpRequestAsync(item, msgId, null);
            string message = result?.Result?.CompletionCode.ToString();
            #endregion CCPRequest

            #region CheckForPrevRequests
            var requests = _brokerRequestService.FindAsync(x => x.BrokerId == broker.Id && x.ClientInfoId == client.Id && !x.IsConcluded);
            if(requests != null && requests.Result.Any())
            {
                foreach(var req in requests.Result)
                {
                    req.IsConcluded = true;
                    await _brokerRequestService.UpdateAsync(req);
                }
            }
            #endregion CheckForPrevRequests

            #region CreateBrokerRequest
            BrokerRequest brokerRequest = new()
            {
                BrokerId = broker.Id,
                ClientInfoId = client.Id,
                DateCreated = DateTime.Now,
                Request = JsonConvert.SerializeObject(item),
                MessageId = msgId
            };
            await _brokerRequestService.AddAsync(brokerRequest);
            #endregion CreateBrokerRequest

            return Result<object>.Ok(result);
        }

        public async Task<Result<ProductSectorSet>> GetProductSector(string key)
        {
            #region GetBroker
            if (string.IsNullOrEmpty(key))
            {
                return Result<ProductSectorSet>.Fail("Key cant be empty.");
            }
            var brokers = await _brokerService.FindAsync(x => x.ApiKey == key);
            if (brokers == null || !brokers.Any())
            {
                return Result<ProductSectorSet>.Fail("Invalid API Key.");
            }
            var broker = brokers.FirstOrDefault();
            #endregion GetBroker
            using OperationContextScope scope = new(_client.InnerChannel);
            HttpRequestMessageProperty p = new();
            p.Headers.Add(System.Net.HttpRequestHeader.UserAgent, broker!.Code);
            OperationContext.Current.OutgoingMessageProperties.Add(HttpRequestMessageProperty.Name, p);
            var result = await _client.GetProductSectorSetAsync();
            return Result<ProductSectorSet>.Ok(result.Data);
        }

        public async Task<Result<ProductSet>> GetProductSet(string key, string sectorCode)
        {
            #region GetBroker
            if (string.IsNullOrEmpty(key))
            {
                return Result<ProductSet>.Fail("Key cant be empty.");
            }
            var brokers = await _brokerService.FindAsync(x => x.ApiKey == key);
            if (brokers == null || !brokers.Any())
            {
                return Result<ProductSet>.Fail("Invalid API Key.");
            }
            var broker = brokers.FirstOrDefault();
            #endregion GetBroker
            using OperationContextScope scope = new(_client.InnerChannel);
            HttpRequestMessageProperty p = new();
            p.Headers.Add(System.Net.HttpRequestHeader.UserAgent, broker.Code);
            OperationContext.Current.OutgoingMessageProperties.Add(HttpRequestMessageProperty.Name, p);
            var result = await _client.GetProductSetAsync(sectorCode);

            return Result<ProductSet>.Ok(result.Data);
        }

        public async Task<FP_C.API.Models.Result> RetrievePortfolios(string key, Guid msgId)
        {
            #region GetBroker
            if (string.IsNullOrEmpty(key))
            {
                return FP_C.API.Models.Result.Fail("Key cant be empty.");
            }
            var brokers = await _brokerService.FindAsync(x => x.ApiKey == key);
            if (brokers == null || !brokers.Any())
            {
                return FP_C.API.Models.Result.Fail("Invalid API Key.");
            }
            var broker = brokers.FirstOrDefault();
            #endregion GetBroker
            using OperationContextScope scope = new(_client.InnerChannel);
            HttpRequestMessageProperty p = new();
            p.Headers.Add(System.Net.HttpRequestHeader.UserAgent, broker.Code);
            OperationContext.Current.OutgoingMessageProperties.Add(HttpRequestMessageProperty.Name, p);
            var result = await _client.GetMessageHeaderAsync(msgId);
            return FP_C.API.Models.Result.Ok();
        }

        public async Task RunRetrieval()
        {
            // Get open requests
            // Retrieves data
            // Stores data
        }
    }
}
