using ClothingStoreFranchise.NetCore.Common.EntityFramework;
using ClothingStoreFranchise.NetCore.Employees.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ClothingStoreFranchise.NetCore.Employees.Dao.Impl
{
    public class WarehouseDao : BaseAbstractEntitiesDao<Warehouse, long, EmployeesContext>, IWarehouseDao
    {
        public WarehouseDao(EmployeesContext contextContainer) : base(contextContainer)
        {
        }

        protected override IQueryable<Warehouse> QueryTemplate()
        {
            return base.QueryTemplate()
                .Include(w => w.WarehouseEmployees);
        }
    }
}
