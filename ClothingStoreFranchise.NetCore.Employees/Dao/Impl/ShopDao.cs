using ClothingStoreFranchise.NetCore.Common.EntityFramework;
using ClothingStoreFranchise.NetCore.Employees.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ClothingStoreFranchise.NetCore.Employees.Dao.Impl
{
    public class ShopDao : BaseAbstractEntitiesDao<Shop, long, EmployeesContext>, IShopDao
    {
        public ShopDao(EmployeesContext contextContainer) : base(contextContainer)
        {
        }

        protected override IQueryable<Shop> QueryTemplate()
        {
            return base.QueryTemplate()
                .Include(s => s.ShopEmployees);
        }
    }
}
