using ClothingStoreFranchise.NetCore.Common.Constants;
using ClothingStoreFranchise.NetCore.Common.Security;
using ClothingStoreFranchise.NetCore.Employees.Dto;
using ClothingStoreFranchise.NetCore.Employees.Facade;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ClothingStoreFranchise.NetCore.Employees.Controllers
{
    [Route("warehouse-employees")]
    [ApiController]
    public class WarehouseEmployeeController : ControllerBase
    {
        private readonly IWarehouseEmployeeService _warehoseEmployeeService;

        public WarehouseEmployeeController(IWarehouseEmployeeService warehoseEmployeeService)
        {
            _warehoseEmployeeService = warehoseEmployeeService;
        }

        [HttpGet("{id}")]
        [AuthorizeRoles(Role.Admin, Role.WarehouseEmployee)]
        public async Task<ActionResult<WarehouseEmployeeDto>> Get(long id)
        {
            return Ok(await _warehoseEmployeeService.LoadAsync(id));
        }

        [HttpPost]
        [Authorize(Roles = Role.Admin)]
        public async Task<ActionResult<WarehouseEmployeeDto>> Create([FromBody] WarehouseEmployeeDto warehouseEmployeeDto)
        {
            return Created("warehouse-employees", await _warehoseEmployeeService.CreateAsync(warehouseEmployeeDto));
        }

        [HttpPut]
        [Authorize(Roles = Role.Admin)]
        public async Task<ActionResult<WarehouseEmployeeDto>> Update([FromBody] WarehouseEmployeeDto warehouseEmployeeDto)
        {
            return Ok(await _warehoseEmployeeService.UpdateAsync(warehouseEmployeeDto));
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = Role.Admin)]
        public async Task Delete(long id)
        {
            await _warehoseEmployeeService.DeleteAsync(id);
        }
    }
}
