using ClothingStoreFranchise.NetCore.Common.Extensible;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClothingStoreFranchise.NetCore.Employees.Model
{
    public abstract class Building : ExtensibleEntity<long>
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public override long Id { get; set; }
        
        public string Address { get; set; }

        public string Phone { get; set; }
    }
}
