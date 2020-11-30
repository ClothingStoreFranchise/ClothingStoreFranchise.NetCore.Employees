using ClothingStoreFranchise.NetCore.Employees.Dto;
using ClothingStoreFranchise.NetCore.Employees.Dto.Events;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClothingStoreFranchise.NetCore.Employees.Facade
{
    public interface IWarehouseService
    {
        Task CreateAsync(CreateWarehouseEvent @event);

        Task UpdateAsync(UpdateWarehouseEvent @event);

        Task<WarehouseDto> LoadAsync(long id);

        Task<ICollection<WarehouseDto>> LoadAllWithEmployeesCount();
    }
}
