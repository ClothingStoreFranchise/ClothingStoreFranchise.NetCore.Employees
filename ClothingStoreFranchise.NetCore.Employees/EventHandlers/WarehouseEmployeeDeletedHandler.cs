using ClothingStoreFranchise.NetCore.Common.Events;
using ClothingStoreFranchise.NetCore.Employees.Dto.Events;
using ClothingStoreFranchise.NetCore.Employees.Facade;
using System.Threading.Tasks;

namespace ClothingStoreFranchise.NetCore.Employees.EventHandlers
{
    public class WarehouseEmployeeDeletedHandler : IIntegrationEventHandler<DeleteWarehouseEmployeeEvent>
    {
        private readonly IWarehouseEmployeeService _warehouseEmployeeService;

        public WarehouseEmployeeDeletedHandler(IWarehouseEmployeeService warehouseEmployeeService)
        {
            _warehouseEmployeeService = warehouseEmployeeService;
        }

        public async Task HandleAsync(DeleteWarehouseEmployeeEvent @event)
        {
            await _warehouseEmployeeService.DeleteAsync(@event.Id);
        }
    }
}
