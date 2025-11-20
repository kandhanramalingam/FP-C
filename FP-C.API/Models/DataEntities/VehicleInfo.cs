namespace FP_C.API.Models.DataEntities
{
    public class VehicleInfo : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
        public string ValuePrev { get; set; } = string.Empty;
        public int ClientInfoId { get; set; }
        public ClientInfo ClientInfo { get; set; }
    }
}
