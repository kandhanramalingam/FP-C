namespace CPR.API.Models.DataEntities
{
    public class AstuteRequest : BaseEntity
    {
        public Guid MessageId { get; set; }
        public int BrokerRequestId { get; set; }
        public BrokerRequest BrokerRequest { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public bool Result { get; set; } = false;
        public string Message { get; set; } = string.Empty;
        public bool IsConcluded { get; set; } = false;
    }
}
