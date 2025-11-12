namespace CPR.API.Models
{
    public class PortfolioPayload
    {
        public PortfolioPayload()
        {

        }

        public PortfolioPayload(string idNumber, string surname, string initials, string cellNumber, string email)
        {
            IdNumber = idNumber;
            Surname = surname;
            Initials = initials;
            CellNumber = cellNumber;
            Email = email;
        }

        public string IdNumber { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string Initials { get; set; } = string.Empty;
        public string CellNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
