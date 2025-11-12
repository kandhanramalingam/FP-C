using FP_C.API.Data.Interfaces;
using FP_C.API.Models.DataEntities;
using FP_C.API.Services.Interfaces;

namespace FP_C.API.Services
{
    public class BrokerService(IUnitOfWork unitOfWork) : BaseService<Broker>(unitOfWork), IBrokerService
    {

    }
}
