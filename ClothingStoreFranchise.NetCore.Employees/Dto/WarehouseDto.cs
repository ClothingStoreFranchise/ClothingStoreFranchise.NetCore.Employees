using System.Collections.Generic;

namespace ClothingStoreFranchise.NetCore.Employees.Dto
{
    public class WarehouseDto : BuildingDto
    {
        public virtual ICollection<WarehouseEmployeeDto> WarehouseEmployees { get; set; }
    }
}
