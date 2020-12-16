using AutoMapper;
using ClothingStoreFranchise.NetCore.Employees.Dto;
using ClothingStoreFranchise.NetCore.Employees.Model;

namespace ClothingStoreFranchise.NetCore.Employees.Mapper
{
    public class WarehouseEmployeeProvider : Profile
    {
        public WarehouseEmployeeProvider()
        {
            CreateMap<WarehouseEmployeeDto, WarehouseEmployee>();

            CreateMap<WarehouseEmployee, WarehouseEmployeeDto>();
        }
    }
}