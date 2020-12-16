using System.ComponentModel.DataAnnotations.Schema;

namespace ClothingStoreFranchise.NetCore.Employees.Model
{
    public class WarehouseEmployee : FranchiseEmployee
    {
        [ForeignKey("Warehouse")]
        public long WarehouseId { get; set; }

        public Warehouse Warehouse { get; set; }

        public override long GetAppId()
        {
            return Id;
        }
    }
}
