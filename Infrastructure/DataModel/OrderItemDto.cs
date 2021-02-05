using StoreakApiService.Core.Context.DataModel;
using System;

namespace ECommerce.Infrastructure.DataModel
{
    public class OrderItemDto : TrackableDto
    {
        public Guid OrderId { get; set; }
        public Guid ItemId { get; set; }
        public int Quantity { get; set; }
        public decimal PricePerUnit { get; set; }
        public decimal Total { get; set; }
        public virtual OrderDto Order { get; set; }
        public virtual ItemDto Item { get; set; }
    }
}
