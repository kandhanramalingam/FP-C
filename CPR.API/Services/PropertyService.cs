using CPR.API.Data.Interfaces;
using CPR.API.Models.DataEntities;
using CPR.API.Services.Interfaces;

namespace CPR.API.Services
{
    public class PropertyService : BaseService<PropertyInfo>, IPropertyService
    {
        public PropertyService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
