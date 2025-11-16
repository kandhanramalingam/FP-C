namespace FP_C.API.Models.DataEntities
{
    public class PolicyInfo : BaseEntity
    {
        public string PolicyNumber { get; set; } = string.Empty;
        public string ProviderCode { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
        public int ClientInfoId { get; set; }
        public ClientInfo ClientInfo { get; set; }
    }
}
