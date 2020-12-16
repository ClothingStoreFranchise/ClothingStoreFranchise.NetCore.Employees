using System.ComponentModel.DataAnnotations.Schema;

namespace ClothingStoreFranchise.NetCore.Employees.Model
{
    public class ShopEmployee : FranchiseEmployee
    {
        [ForeignKey("Shop")]
        public long ShopId { get; set; }

        public Shop Shop { get; set; }

        public override long GetAppId()
        {
            return Id;
        }
    }
}
