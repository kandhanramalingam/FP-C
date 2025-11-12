namespace FP_C.API.Models.DataEntities
{
    public class PropertyInfo : BaseEntity
    {
        public double OrgininalValue { get; set; }
        public double CurrentValue { get; set; }
        public int ClientInfoId { get; set; }
        public ClientInfo ClientInfo { get; set; }
    }
}
