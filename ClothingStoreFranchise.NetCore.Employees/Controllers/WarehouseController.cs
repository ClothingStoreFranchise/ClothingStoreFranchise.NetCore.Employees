using ClothingStoreFranchise.NetCore.Employees.Dto;
using ClothingStoreFranchise.NetCore.Employees.Facade;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClothingStoreFranchise.NetCore.Employees.Controllers
{
    [Route("warehouses")]
    [ApiController]
    public class WarehouseController : ControllerBase
    {
        private readonly IWarehouseService _warehouseService;

        public WarehouseController(IWarehouseService warehouseService)
        {
            _warehouseService = warehouseService;
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<WarehouseDto>>> GetAll()
        {
            return Ok(await _warehouseService.LoadAllWithEmployeesCount());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<WarehouseDto>> Get(long id)
        {
            return Ok(await _warehouseService.LoadAsync(id));
        }
    }
}
