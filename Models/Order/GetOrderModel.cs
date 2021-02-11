using ECommerce.Infrastructure.DataModel;
using ECommerce.Models.Queries.OrderItem;
using System;
using System.Collections.Generic;

namespace ECommerce.Models.Queries.Order
{
    public class GetOrderModel
    {
        public int OrderNo { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? ShipDate { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public decimal Total { get; set; }
        public virtual ICollection<GetOrderItemModel> OrderItems { get; set; }
    }
}
