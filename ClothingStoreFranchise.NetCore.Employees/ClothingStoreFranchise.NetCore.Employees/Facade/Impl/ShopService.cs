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
    public class ShopService : EmployeeBaseService<Shop, long, ShopDto, IShopDao>, IShopService
    {
        public ShopService(IShopDao shopDao, IMapper mapper) : base(shopDao, mapper)
        {
        }

        public async Task CreateAsync(CreateShopEvent @event)
        {
            await base.CreateAsync(@event);
        }

        public async Task UpdateAsync(UpdateShopEvent @event)
        {
            await base.UpdateAsync(@event);
        }

        public override async Task<ShopDto> LoadAsync(long id)
        {
            Shop shop = await _entityDao.FindByIdAsync(id);
            var shopEmployees = shop.ShopEmployees;
            ShopDto shopDto =  _mapper.Map<ShopDto>(shop);
            shopDto.ShopEmployees = shopEmployees.Select(l => _mapper.Map<ShopEmployeeDto>(l)).ToList();
            return shopDto;
        }

        public async Task<ICollection<ShopDto>> LoadAllWithEmployeesCount()
        {
            ICollection<Shop> shops = await _entityDao.LoadAllAsync();
            ICollection<ShopDto> shopDtos = new List<ShopDto>();
            foreach (var shop in shops)
            {
                ShopDto shopDto = _mapper.Map<ShopDto>(shop);
                shopDto.EmployeeCount = shop.ShopEmployees.Count;
                shopDtos.Add(shopDto);
            }
            return shopDtos;
        }

        protected override Expression<Func<Shop, bool>> EntityAlreadyExistsCondition(ShopDto dto)
        {
            throw new NotImplementedException();
        }

        protected override Expression<Func<Shop, bool>> EntityHasDependenciesToDeleteCondition(ICollection<long> listAppIds)
        {
            throw new NotImplementedException();
        }

        protected override bool IsValid(ShopDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
