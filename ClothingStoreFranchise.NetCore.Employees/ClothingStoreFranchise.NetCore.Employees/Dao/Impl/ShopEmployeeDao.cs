using ClothingStoreFranchise.NetCore.Common.EntityFramework;
using ClothingStoreFranchise.NetCore.Employees.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClothingStoreFranchise.NetCore.Employees.Dao.Impl
{
    public class ShopEmployeeDao : BaseAbstractEntitiesDao<ShopEmployee, long, EmployeesContext>, IShopEmployeeDao
    {
        public ShopEmployeeDao(EmployeesContext contextContainer) : base(contextContainer)
        {
        }
    }
}
