using ClothingStoreFranchise.NetCore.Common.Constants;
using ClothingStoreFranchise.NetCore.Employees.Dto;
using ClothingStoreFranchise.NetCore.Employees.Facade;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClothingStoreFranchise.NetCore.Employees.Controllers
{
    [Route("shops")]
    [ApiController]
    [Authorize(Roles = Role.Admin)]
    public class ShopController : ControllerBase
    {
        private readonly IShopService _shopService;

        public ShopController(IShopService shopService)
        {
            _shopService = shopService;
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<ShopDto>>> GetAll()
        {
            return Ok(await _shopService.LoadAllWithEmployeesCount());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ShopDto>> Get(long id)
        {
            return Ok(await _shopService.LoadAsync(id));
        }
    }
}
