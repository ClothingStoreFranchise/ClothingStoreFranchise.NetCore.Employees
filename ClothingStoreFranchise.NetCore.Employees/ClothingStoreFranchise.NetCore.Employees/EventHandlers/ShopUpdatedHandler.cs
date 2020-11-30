using ClothingStoreFranchise.NetCore.Common.Events;
using ClothingStoreFranchise.NetCore.Employees.Dto.Events;
using ClothingStoreFranchise.NetCore.Employees.Facade;
using System.Threading.Tasks;

namespace ClothingStoreFranchise.NetCore.Employees.EventHandlers
{
    public class ShopUpdatedHandler : IIntegrationEventHandler<UpdateShopEvent>
    {
        private readonly IShopService _shopService;

        public ShopUpdatedHandler(IShopService shopService)
        {
            _shopService = shopService;
        }

        public async Task HandleAsync(UpdateShopEvent @event)
        {
            await _shopService.UpdateAsync(@event);
        }
    }
}