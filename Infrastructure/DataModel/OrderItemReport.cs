using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Infrastructure.DataModel
{
    public class OrderItemReport
    {
        public DateTime CreatedDate { get; set; }
        public Guid ItemId { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get; set; }
    }
}
