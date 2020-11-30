using ClothingStoreFranchise.NetCore.Common.Types;

namespace ClothingStoreFranchise.NetCore.Employees.Dto
{
    public abstract class EmpoyeeDto : IEntityDto<long>
    {
        public long Id { get; set; }

        public string Username { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public string AccountNumber { get; set; }

        public string SSecurityNumber { get; set; }

        public long Salary { get; set; }

        public long Key()
        {
            return Id;
        }
    }
}
