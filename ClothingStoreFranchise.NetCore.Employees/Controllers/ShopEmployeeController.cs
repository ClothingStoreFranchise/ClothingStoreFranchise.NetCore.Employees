using ClothingStoreFranchise.NetCore.Common.Constants;
using ClothingStoreFranchise.NetCore.Common.Security;
using ClothingStoreFranchise.NetCore.Employees.Dto;
using ClothingStoreFranchise.NetCore.Employees.Facade;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ClothingStoreFranchise.NetCore.Employees.Controllers
{
    [Route("shop-employees")]
    [ApiController]
    public class ShopEmployeeController : ControllerBase
    {
        private readonly IShopEmployeeService _shopEmployeeService;

        public ShopEmployeeController(IShopEmployeeService shopEmployeeService)
        {
            _shopEmployeeService = shopEmployeeService;
        }

        [HttpGet("{id}")]
        [AuthorizeRoles(Role.Admin, Role.ShopEmployee)]
        public async Task<ActionResult<ShopEmployeeDto>> Get(long id)
        {
            return Ok(await _shopEmployeeService.LoadAsync(id));
        }

        [HttpPost]
        [Authorize(Roles = Role.Admin)]
        public async Task<ActionResult<ShopEmployeeDto>> Create([FromBody] ShopEmployeeDto shopEmployeeDto)
        {
            return Created("shop-employees", await _shopEmployeeService.CreateAsync(shopEmployeeDto));
        }

        [HttpPut]
        [Authorize(Roles = Role.Admin)]
        public async Task<ActionResult<ShopEmployeeDto>> Update([FromBody] ShopEmployeeDto shopEmployeeDto)
        {
            return Ok(await _shopEmployeeService.UpdateAsync(shopEmployeeDto));
        }
    }
}
