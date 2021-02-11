using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Infrastructure.DataModel
{
    public class OrderReport
    {
        public DateTime CreatedDate { get; set; }
        public int TotalOrders { get; set; }
        public int CancelledOrders { get; set; }

    }
}
