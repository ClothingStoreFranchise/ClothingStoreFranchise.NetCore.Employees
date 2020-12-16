using System.Collections.Generic;

namespace ClothingStoreFranchise.NetCore.Employees.Model
{
    public class Warehouse : Building
    {
        public ICollection<WarehouseEmployee> WarehouseEmployees { get; set; }

        public override long GetAppId()
        {
            return Id;
        }
    }
}
