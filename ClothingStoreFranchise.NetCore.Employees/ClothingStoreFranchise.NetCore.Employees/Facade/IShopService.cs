using ClothingStoreFranchise.NetCore.Employees.Dto;
using ClothingStoreFranchise.NetCore.Employees.Dto.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClothingStoreFranchise.NetCore.Employees.Facade
{
    public interface IShopService
    {
        Task CreateAsync(CreateShopEvent @event);

        Task UpdateAsync(UpdateShopEvent @event);

        Task<ShopDto> LoadAsync(long id);

        Task<ICollection<ShopDto>> LoadAllWithEmployeesCount();
    }
}
