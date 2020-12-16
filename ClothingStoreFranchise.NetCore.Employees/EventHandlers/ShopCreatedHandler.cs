using ClothingStoreFranchise.NetCore.Common.Events;
using ClothingStoreFranchise.NetCore.Employees.Dto.Events;
using ClothingStoreFranchise.NetCore.Employees.Facade;
using System.Threading.Tasks;

namespace ClothingStoreFranchise.NetCore.Employees.EventHandlers
{
    public class ShopCreatedHandler : IIntegrationEventHandler<CreateShopEvent>
    {
        private readonly IShopService _shopService;

        public ShopCreatedHandler(IShopService shopService)
        {
            _shopService = shopService;
        }

        public async Task HandleAsync(CreateShopEvent @event)
        {
            await _shopService.CreateAsync(@event);
        }
    }
}
