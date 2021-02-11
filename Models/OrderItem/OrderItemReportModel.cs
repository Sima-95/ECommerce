using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Models.Queries.OrderItem
{
    public class OrderItemReportModel
    {
        public DateTime CreatedDate { get; set; }
        public Guid ItemId { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get; set; }
    }
}
