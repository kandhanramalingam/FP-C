using CPR.API.Data.Interfaces;
using CPR.API.Models.DataEntities;
using CPR.API.Services.Interfaces;

namespace CPR.API.Services
{
    public class BrokerRequestService(IUnitOfWork unitOfWork) : BaseService<BrokerRequest>(unitOfWork), IBrokerRequestService
    {

    }
}
