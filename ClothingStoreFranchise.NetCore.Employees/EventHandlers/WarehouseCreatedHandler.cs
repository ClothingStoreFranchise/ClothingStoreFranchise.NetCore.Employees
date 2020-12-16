using ClothingStoreFranchise.NetCore.Common.Events;
using ClothingStoreFranchise.NetCore.Employees.Dto.Events;
using ClothingStoreFranchise.NetCore.Employees.Facade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClothingStoreFranchise.NetCore.Employees.EventHandlers
{
    public class WarehouseCreatedHandler : IIntegrationEventHandler<CreateWarehouseEvent>
    {
        private readonly IWarehouseService _warehouseService;

        public WarehouseCreatedHandler(IWarehouseService warehouseService)
        {
            _warehouseService = warehouseService;
        }

        public async Task HandleAsync(CreateWarehouseEvent @event)
        {
            await _warehouseService.CreateAsync(@event);
        }
    }
}

