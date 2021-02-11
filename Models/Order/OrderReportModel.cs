using System;

namespace ECommerce.Models.Queries.Order
{
    public class OrderReportModel
    {
        public DateTime CreatedDate { get; set; }
        public int TotalOrders { get; set; }
        public int CancelledOrders { get; set; }
    }
}
