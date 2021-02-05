using StoreakApiService.Core.Context.DataModel;
using System;
using System.Collections.Generic;

namespace ECommerce.Infrastructure.DataModel
{
    public class OrderDto : TrackableDto
    {
        public OrderDto()
        {
            OrderItems = new HashSet<OrderItemDto>();
        }

        public int  OrderNo { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? ShipDate { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public decimal Total { get; set; }

        public virtual ICollection<OrderItemDto> OrderItems { get; set; }
    }
}
