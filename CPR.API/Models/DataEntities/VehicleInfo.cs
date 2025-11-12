namespace CPR.API.Models.DataEntities
{
    public class VehicleInfo : BaseEntity
    {
        //Make
        //Model
        //Year
        //Description
        public double OrgininalValue { get; set; }
        public double CurrentValue { get; set; }
        public int ClientInfoId { get; set; }
        public ClientInfo ClientInfo { get; set; }
    }
}
