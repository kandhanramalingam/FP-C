namespace FP_C.API.Models.DataEntities
{
    public class Broker : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string FSNumber { get; set; } = string.Empty;
        public string ApiKey { get; set; }
        public ICollection<BrokerRequest> BrokerRequests { get; set; }
    }
}
