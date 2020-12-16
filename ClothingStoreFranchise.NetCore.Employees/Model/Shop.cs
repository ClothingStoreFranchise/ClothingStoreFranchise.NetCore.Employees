using System.Collections.Generic;

namespace ClothingStoreFranchise.NetCore.Employees.Model
{
    public class Shop : Building
    {
        public ICollection<ShopEmployee> ShopEmployees { get; set; }

        public override long GetAppId()
        {
            return Id;
        }
    }
}
