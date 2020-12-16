using ClothingStoreFranchise.NetCore.Employees.Dto;
using System.Threading.Tasks;

namespace ClothingStoreFranchise.NetCore.Employees.Facade
{
    public interface IWarehouseEmployeeService
    {
        Task<WarehouseEmployeeDto> CreateAsync(WarehouseEmployeeDto warehouseEmployeeDto);

        Task<WarehouseEmployeeDto> UpdateAsync(WarehouseEmployeeDto warehouseEmployeeDto);

        Task<WarehouseEmployeeDto> LoadAsync(long id);

        Task DeleteAsync(long id);
    }
}
