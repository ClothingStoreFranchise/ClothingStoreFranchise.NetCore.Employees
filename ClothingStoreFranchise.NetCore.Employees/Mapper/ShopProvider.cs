using AutoMapper;
using ClothingStoreFranchise.NetCore.Employees.Dto;
using ClothingStoreFranchise.NetCore.Employees.Dto.Events;
using ClothingStoreFranchise.NetCore.Employees.Model;

namespace ClothingStoreFranchise.NetCore.Employees.Mapper
{
    public class ShopProvider : Profile
    {
        public ShopProvider()
        {
            CreateMap<CreateShopEvent, Shop>();

            CreateMap<UpdateShopEvent, Shop>();

            CreateMap<Shop, ShopDto>()
                .ForMember(dest => dest.ShopEmployees, opt => opt.Ignore());
        }
    }
}
