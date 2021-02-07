using ClothingStoreFranchise.NetCore.Common.Events.Impl;
using ClothingStoreFranchise.NetCore.Common.Types;

namespace ClothingStoreFranchise.NetCore.Employees.Dto.Events
{
    public class DeleteShopEmployeeEvent : IntegrationEvent, IEntityDto<long>
    {
        public long Id { get; set; }

        public long Key()
        {
            return Id;
        }
    }
}
