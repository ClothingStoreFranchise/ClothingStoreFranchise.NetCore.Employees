using ClothingStoreFranchise.NetCore.Common.Events;
using ClothingStoreFranchise.NetCore.Employees.Dto.Events;
using ClothingStoreFranchise.NetCore.Employees.Facade;
using System.Threading.Tasks;

namespace ClothingStoreFranchise.NetCore.Employees.EventHandlers
{
    public class ShopEmployeeDeletedHandler : IIntegrationEventHandler<DeleteShopEmployeeEvent>
    {
        private readonly IShopEmployeeService _shopEmployeeService;

        public ShopEmployeeDeletedHandler(IShopEmployeeService shopEmployeeService)
        {
            _shopEmployeeService = shopEmployeeService;
        }

        public async Task HandleAsync(DeleteShopEmployeeEvent @event)
        {
            await _shopEmployeeService.DeleteAsync(@event.Id);
        }
    }
}
