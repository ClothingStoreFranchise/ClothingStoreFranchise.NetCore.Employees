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
    public class ShopEmployeeService : EmployeeBaseService<ShopEmployee, long, ShopEmployeeDto, IShopEmployeeDao>, IShopEmployeeService
    {
        public ShopEmployeeService(IShopEmployeeDao shopEmployeeDao, IMapper mapper) : base(shopEmployeeDao, mapper)
        {
        }

        protected override Expression<Func<ShopEmployee, bool>> EntityAlreadyExistsCondition(ShopEmployeeDto dto)
        {
            return e => e.Id == dto.Id;
        }

        protected override Expression<Func<ShopEmployee, bool>> EntityHasDependenciesToDeleteCondition(ICollection<long> listAppIds)
        {
            throw new NotImplementedException();
        }

        protected override bool IsValid(ShopEmployeeDto dto)
        {
            return NullValidations(dto) && NumericValidations(dto);
        }

        private static bool NullValidations(ShopEmployeeDto dto)
        {
            return dto != null
                && !string.IsNullOrWhiteSpace(dto.Username)
                && !string.IsNullOrWhiteSpace(dto.LastName)
                && !string.IsNullOrWhiteSpace(dto.Address)
                && !string.IsNullOrWhiteSpace(dto.Email)
                && !string.IsNullOrWhiteSpace(dto.AccountNumber)
                && !string.IsNullOrWhiteSpace(dto.SSecurityNumber);
        }

        private static bool NumericValidations(ShopEmployeeDto dto)
        {
            return dto.Salary > 100;
        }
    }
}
