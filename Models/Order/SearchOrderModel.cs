using ECommerce.Infrastructure.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Models.Queries.Order
{
    public class SearchOrderModel
    {
        public int OrderNo { get; set; }
        public DateTime? OrderDate { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public decimal Total { get; set; }
    }
}
