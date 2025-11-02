using CPR.API.Data.Interfaces;
using CPR.API.Models.DataEntities;
using CPR.API.Services.Interfaces;

namespace CPR.API.Services
{
    public class ClientService : BaseService<ClientInfo>, IClientService
    {
        public ClientService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
    }
}
