namespace FP_C.API.Models
{
    public class PropertyPayload
    {
        public string buyerName { get; set; } = string.Empty;
        public string sellerName { get; set; } = string.Empty;
        public string purchaseDate { get; set; } = string.Empty;
        public int purchasePrice { get; set; } = 0;
        public string registrationDate { get; set; } = string.Empty;
        public string titleDeed { get; set; } = string.Empty;
        public int propertyId { get; set; } = 0;
    }
}
