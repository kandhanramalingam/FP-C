using AstuteServiceReference;
using CPR.API.Models;
using CPR.API.Models.DataEntities;

namespace CPR.API.Common
{
    public static class Extensions
    {
        public static CcpRequestDetails GetPortfolio(this PortfolioPayload value)
        {
            CcpRequestDetails request = new();
            if(value != null)
            {
                request.IdNumber = value.IdNumber;
                request.IdType = IdType.SouthAfrican;
                request.Surname = value.Surname;
                request.Initials = value.Initials;
                request.DateOfBirth = MyCommon.GetDOB(value.IdNumber);
                request.CellNumber = value.CellNumber;
                request.EmailAddress = value.Email;
                request.OverrideDigitalConsent = true;
                request.RequestDetails = MyCommon.GetAllProviders();
            }
            return request;
        }

        public static ClientInfo ToClient(this PortfolioPayload value)
        {
            ClientInfo client = new();
            if(value != null)
            {
                client.IdNumber = value.IdNumber;
                client.Surname = value.Surname;
                client.Initials = value.Initials;
                client.DOB = MyCommon.GetDOB(value.IdNumber);
                client.PhoneNumber = value.CellNumber;
                client.Email = value.Email;
                client.Properties = [];
            }
            return client;
        }
    }
}
