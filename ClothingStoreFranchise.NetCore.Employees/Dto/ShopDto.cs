using System.Collections.Generic;

namespace ClothingStoreFranchise.NetCore.Employees.Dto
{
    public class ShopDto : BuildingDto
    {
        public virtual ICollection<ShopEmployeeDto> ShopEmployees { get; set; }
    }
}
