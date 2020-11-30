using ClothingStoreFranchise.NetCore.Common.EntityFramework;
using ClothingStoreFranchise.NetCore.Employees.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClothingStoreFranchise.NetCore.Employees.Dao.Impl
{
    public class WarehouseEmployeeDao : BaseAbstractEntitiesDao<WarehouseEmployee, long, EmployeesContext>, IWarehouseEmployeeDao
    {
        public WarehouseEmployeeDao(EmployeesContext contextContainer) : base(contextContainer)
        {
        }
    }
}
