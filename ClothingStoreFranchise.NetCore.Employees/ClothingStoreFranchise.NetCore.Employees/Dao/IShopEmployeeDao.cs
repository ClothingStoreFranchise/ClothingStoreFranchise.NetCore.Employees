using ClothingStoreFranchise.NetCore.Common.Types;
using ClothingStoreFranchise.NetCore.Employees.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClothingStoreFranchise.NetCore.Employees.Dao
{
    public interface IShopEmployeeDao : IDao<ShopEmployee, long>
    {
    }
}
