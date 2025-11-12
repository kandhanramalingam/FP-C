using CPR.API.Data.Interfaces;
using CPR.API.Models.DataEntities;
using CPR.API.Services.Interfaces;

namespace CPR.API.Services
{
    public class PolicyService(IUnitOfWork unitOfWork) : BaseService<PolicyInfo>(unitOfWork), IPolicyService
    {
    }
}
