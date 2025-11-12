namespace CPR.API.Models.DataEntities
{
    public class PolicyInfo : BaseEntity
    {
        public string PolicyNumber { get; set; }
        public int ClientInfoId { get; set; }
        public ClientInfo ClientInfo { get; set; }
    }
}
