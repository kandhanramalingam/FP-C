namespace CPR.API.Models.DataEntities
{
    public class BrokerRequest :BaseEntity
    {
        public int BrokerId { get; set; }
        public Broker Broker { get; set; }
        public DateTime DateCreated { get; set; }
        public int ClientInfoId { get; set; }
        public ClientInfo ClientInfo { get; set; }
        public ICollection<AstuteRequest> AstuteRequests { get; set; }

    }
}
