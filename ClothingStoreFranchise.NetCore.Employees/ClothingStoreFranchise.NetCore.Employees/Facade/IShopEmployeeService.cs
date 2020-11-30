using ClothingStoreFranchise.NetCore.Employees.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClothingStoreFranchise.NetCore.Employees.Facade
{
    public interface IShopEmployeeService
    {
        Task<ShopEmployeeDto> CreateAsync(ShopEmployeeDto shopEmployeeDto);

        Task<ShopEmployeeDto> UpdateAsync(ShopEmployeeDto shopEmployeeDto);

        Task<ShopEmployeeDto> LoadAsync(long id);

        Task DeleteAsync(long id);
    }
}
