namespace FP_C.API.Models.DataEntities
{
    public class BrokerRequest : BaseEntity
    {
        public int BrokerId { get; set; }
        public Broker Broker { get; set; }
        public DateTime DateCreated { get; set; }
        public int ClientInfoId { get; set; }
        public ClientInfo ClientInfo { get; set; }
        public bool Result { get; set; } = false;
        public string Message { get; set; } = string.Empty;
        public string Request { get; set; } = string.Empty;
        public Guid MessageId { get; set; }
        public bool IsConcluded { get; set; } = false;

    }
}
