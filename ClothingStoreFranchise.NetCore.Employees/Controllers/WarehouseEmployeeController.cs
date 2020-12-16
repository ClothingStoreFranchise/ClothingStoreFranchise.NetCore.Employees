using ClothingStoreFranchise.NetCore.Employees.Dto;
using ClothingStoreFranchise.NetCore.Employees.Facade;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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

        [HttpPost]
        public async Task<ActionResult<WarehouseEmployeeDto>> Create([FromBody] WarehouseEmployeeDto warehouseEmployeeDto)
        {
            return Ok(await _warehoseEmployeeService.CreateAsync(warehouseEmployeeDto));
        }

        [HttpPut]
        public async Task<ActionResult<WarehouseEmployeeDto>> Update([FromBody] WarehouseEmployeeDto warehouseEmployeeDto)
        {
            return Ok(await _warehoseEmployeeService.UpdateAsync(warehouseEmployeeDto));
        }

        [HttpDelete("{id}")]
        public async Task Delete(long id)
        {
            await _warehoseEmployeeService.DeleteAsync(id);
        }
    }
}
