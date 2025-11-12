namespace FP_C.API.Models.DataEntities
{
    public class AstuteRequest : BaseEntity
    {
        
        public int BrokerRequestId { get; set; }
        public BrokerRequest BrokerRequest { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        
    }
}
