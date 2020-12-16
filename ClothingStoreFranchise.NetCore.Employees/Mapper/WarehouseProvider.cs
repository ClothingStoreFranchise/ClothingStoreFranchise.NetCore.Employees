using AutoMapper;
using ClothingStoreFranchise.NetCore.Employees.Dto;
using ClothingStoreFranchise.NetCore.Employees.Dto.Events;
using ClothingStoreFranchise.NetCore.Employees.Model;

namespace ClothingStoreFranchise.NetCore.Employees.Mapper
{
    public class WarehouseProvider : Profile
    {
        public WarehouseProvider()
        {
            CreateMap<CreateWarehouseEvent, Warehouse>();

            CreateMap<UpdateWarehouseEvent, Warehouse>();

            CreateMap<Warehouse, WarehouseDto>()
                .ForMember(dest => dest.WarehouseEmployees, opt => opt.Ignore());
        }
    }
}
