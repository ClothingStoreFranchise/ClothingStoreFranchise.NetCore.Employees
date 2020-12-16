using ClothingStoreFranchise.NetCore.Common.Extensible;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClothingStoreFranchise.NetCore.Employees.Model
{
    public abstract class FranchiseEmployee : ExtensibleEntity<long>
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public override long Id { get; set; }

        public string Username { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public string AccountNumber { get; set; }

        public string SSecurityNumber { get; set; }

        public decimal Salary { get; set; }
    }
}
