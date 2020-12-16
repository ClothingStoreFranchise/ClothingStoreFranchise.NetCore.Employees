using AutoMapper;
using ClothingStoreFranchise.NetCore.Employee.Facade.Impl;
using ClothingStoreFranchise.NetCore.Employees.Dao;
using ClothingStoreFranchise.NetCore.Employees.Dto;
using ClothingStoreFranchise.NetCore.Employees.Dto.Events;
using ClothingStoreFranchise.NetCore.Employees.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ClothingStoreFranchise.NetCore.Employees.Facade.Impl
{
    public class WarehouseService : EmployeeBaseService<Warehouse, long, WarehouseDto, IWarehouseDao>, IWarehouseService
    {
        private readonly IWarehouseDao _warehouseDao;

        public WarehouseService(IWarehouseDao warehouseDao, IMapper mapper) : base(warehouseDao, mapper)
        {
            _warehouseDao = warehouseDao;
        }

        public async Task CreateAsync(CreateWarehouseEvent @event)
        {
            await base.CreateAsync(@event);
        }

        public async Task UpdateAsync(UpdateWarehouseEvent @event)
        {
            await base.UpdateAsync(@event);
        }

        public override async Task<WarehouseDto> LoadAsync(long id)
        {
            Warehouse warehouse = await _entityDao.FindByIdAsync(id);
            var shopEmployees = warehouse.WarehouseEmployees;
            WarehouseDto WarehouseDto = _mapper.Map<WarehouseDto>(warehouse);
            WarehouseDto.WarehouseEmployees = shopEmployees.Select(l => _mapper.Map<WarehouseEmployeeDto>(l)).ToList();
            return WarehouseDto;
        }

        public async Task<ICollection<WarehouseDto>> LoadAllWithEmployeesCount()
        {
            ICollection<Warehouse> warehouses = await _warehouseDao.LoadAllAsync();
            ICollection<WarehouseDto> warehouseDtos = new List<WarehouseDto>();
            foreach (var warehouse in warehouses)
            {
                WarehouseDto warehouseDto = _mapper.Map<WarehouseDto>(warehouse);
                warehouseDto.EmployeeCount = warehouse.WarehouseEmployees.Count;
                warehouseDtos.Add(warehouseDto);
            }
            return warehouseDtos;
        }

        protected override Expression<Func<Warehouse, bool>> EntityAlreadyExistsCondition(WarehouseDto dto)
        {
            throw new NotImplementedException();
        }

        protected override Expression<Func<Warehouse, bool>> EntityHasDependenciesToDeleteCondition(ICollection<long> listAppIds)
        {
            throw new NotImplementedException();
        }

        protected override bool IsValid(WarehouseDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
