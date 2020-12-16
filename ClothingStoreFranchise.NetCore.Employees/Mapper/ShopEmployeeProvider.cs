using AutoMapper;
using ClothingStoreFranchise.NetCore.Employees.Dto;
using ClothingStoreFranchise.NetCore.Employees.Model;

namespace ClothingStoreFranchise.NetCore.Employees.Mapper
{
    public class ShopEmployeeProvider : Profile
    {
        public ShopEmployeeProvider()
        {
            CreateMap<ShopEmployeeDto, ShopEmployee>();

            CreateMap<ShopEmployee, ShopEmployeeDto>();
        }
    }
}
