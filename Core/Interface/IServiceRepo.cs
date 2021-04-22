using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entity;

namespace Core.Interface
{
    public interface IServiceRepo
    {
        Task<Service> GetServiceByIdAsync(int id);

        Task<IReadOnlyList<Service>> GetServicesAsync();
        Task<IReadOnlyList<ServiceType>> GetServiceTypesAsync();
        Task<IReadOnlyList<CommType>> GetCommTypesAsync();
        Task<IReadOnlyList<DesignOption>> GetDesignOptionsAsync();


    }
}