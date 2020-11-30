using ClothingStoreFranchise.NetCore.Common.Events.Impl;
using ClothingStoreFranchise.NetCore.Common.Types;
using Newtonsoft.Json;

namespace ClothingStoreFranchise.NetCore.Employees.Dto.Events
{
    public abstract class BuildingEvent : IntegrationEvent, IEntityDto<long>
    {
        [JsonProperty(PropertyName = "id")]
        public long Id { get; set; }

        [JsonProperty(PropertyName = "address")]
        public string Address { get; set; }

        [JsonProperty(PropertyName = "phone")]
        public string Phone { get; set; }

        public long Key() => Id;
    }
}
