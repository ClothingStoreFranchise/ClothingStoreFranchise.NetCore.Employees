using ClothingStoreFranchise.NetCore.Common.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClothingStoreFranchise.NetCore.Employees.Dto
{
    public class ShopEmployeeDto : EmpoyeeDto
    {
        public long ShopId { get; set; }

    }
}
