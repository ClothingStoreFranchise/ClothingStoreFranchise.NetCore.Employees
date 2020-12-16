using ClothingStoreFranchise.NetCore.Common.Events;
using ClothingStoreFranchise.NetCore.Employees.Dto.Events;
using ClothingStoreFranchise.NetCore.Employees.Facade;
using System.Threading.Tasks;

namespace ClothingStoreFranchise.NetCore.Employees.EventHandlers
{
    public class WarehouseUpdatedHandler : IIntegrationEventHandler<UpdateWarehouseEvent>
    {
        private readonly IWarehouseService _warehouseService;

        public WarehouseUpdatedHandler(IWarehouseService warehouseService)
        {
            _warehouseService = warehouseService;
        }

        public async Task HandleAsync(UpdateWarehouseEvent @event)
        {
            await _warehouseService.UpdateAsync(@event);
        }
    }
}
