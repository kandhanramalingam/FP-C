using CPR.API.Data.Interfaces;
using CPR.API.Models.DataEntities;
using CPR.API.Services.Interfaces;

namespace CPR.API.Services
{
    public class VehicleService(IUnitOfWork unitOfWork) : BaseService<VehicleInfo>(unitOfWork), IVehicleService
    {
    }
}
