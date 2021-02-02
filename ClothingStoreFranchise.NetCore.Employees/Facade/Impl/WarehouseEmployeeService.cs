using AutoMapper;
using ClothingStoreFranchise.NetCore.Employee.Facade.Impl;
using ClothingStoreFranchise.NetCore.Employees.Dao;
using ClothingStoreFranchise.NetCore.Employees.Dto;
using ClothingStoreFranchise.NetCore.Employees.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ClothingStoreFranchise.NetCore.Employees.Facade.Impl
{
    public class WarehouseEmployeeService : EmployeeBaseService<WarehouseEmployee, long, WarehouseEmployeeDto, IWarehouseEmployeeDao>, IWarehouseEmployeeService
    {
        public WarehouseEmployeeService(IWarehouseEmployeeDao warehouseEmployeeDao, IMapper mapper) : base(warehouseEmployeeDao, mapper)
        {
        }

        protected override Expression<Func<WarehouseEmployee, bool>> EntityAlreadyExistsCondition(WarehouseEmployeeDto dto)
        {
            return e => e.Id == dto.Id;
        }

        protected override Expression<Func<WarehouseEmployee, bool>> EntityHasDependenciesToDeleteCondition(ICollection<long> listAppIds)
        {
            throw new NotImplementedException();
        }

        protected override bool IsValid(WarehouseEmployeeDto dto)
        {
            return NullValidations(dto) && NumericValidations(dto);
        }

        private static bool NullValidations(WarehouseEmployeeDto dto)
        {
            return dto != null
                && !string.IsNullOrWhiteSpace(dto.Username)
                && !string.IsNullOrWhiteSpace(dto.LastName)
                && !string.IsNullOrWhiteSpace(dto.Address)
                && !string.IsNullOrWhiteSpace(dto.Email)
                && !string.IsNullOrWhiteSpace(dto.AccountNumber)
                && !string.IsNullOrWhiteSpace(dto.SSecurityNumber);
        }

        private static bool NumericValidations(WarehouseEmployeeDto dto)
        {
            return dto.Salary > 100;
        }
    }
}
