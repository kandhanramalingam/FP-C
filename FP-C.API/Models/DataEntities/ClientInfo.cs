namespace FP_C.API.Models.DataEntities
{
    public class ClientInfo : BaseEntity
    {
        public string Surname { get; set; } = string.Empty;
        public string Initials { get; set; } = string.Empty;
        public string IdNumber { get; set; } = string.Empty;
        public DateTime DOB { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public ICollection<PropertyInfo> Properties { get; set; }
        public ICollection<VehicleInfo> Vehicles { get; set; }
        public ICollection<PolicyInfo> Policies { get; set; }
        public ICollection<BrokerRequest> BrokerRequests { get; set; }
    }
}
