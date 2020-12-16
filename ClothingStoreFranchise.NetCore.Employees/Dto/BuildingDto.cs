using ClothingStoreFranchise.NetCore.Common.Types;

namespace ClothingStoreFranchise.NetCore.Employees.Dto
{
    public abstract class BuildingDto : IEntityDto<long>
    {
        public long Id { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public int EmployeeCount { get; set; }

        public long Key() => Id;
    }
}
