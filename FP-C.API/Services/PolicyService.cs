using FP_C.API.Data.Interfaces;
using FP_C.API.Models.DataEntities;
using FP_C.API.Services.Interfaces;

namespace FP_C.API.Services
{
    public class PolicyService(IUnitOfWork unitOfWork) : BaseService<PolicyInfo>(unitOfWork), IPolicyService
    {
    }
}
