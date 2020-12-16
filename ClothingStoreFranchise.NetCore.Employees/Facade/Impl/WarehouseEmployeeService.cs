using AutoMapper;
using ClothingStoreFranchise.NetCore.Employee.Facade.Impl;
using ClothingStoreFranchise.NetCore.Employees.Dao;
using ClothingStoreFranchise.NetCore.Employees.Dto;
using ClothingStoreFranchise.NetCore.Employees.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ClothingStoreFranchise.NetCore.Employees.Facade.Impl
{
    public class WarehouseEmployeeService : EmployeeBaseService<WarehouseEmployee, long, WarehouseEmployeeDto, IWarehouseEmployeeDao>, IWarehouseEmployeeService
    {
        public WarehouseEmployeeService(IWarehouseEmployeeDao warehouseEmployeeDao, IMapper mapper) : base(warehouseEmployeeDao, mapper)
        {
        }

        protected override Expression<Func<WarehouseEmployee, bool>> EntityAlreadyExistsCondition(WarehouseEmployeeDto dto)
        {
            throw new NotImplementedException();
        }

        protected override Expression<Func<WarehouseEmployee, bool>> EntityHasDependenciesToDeleteCondition(ICollection<long> listAppIds)
        {
            throw new NotImplementedException();
        }

        protected override bool IsValid(WarehouseEmployeeDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
