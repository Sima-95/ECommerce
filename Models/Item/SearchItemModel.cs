using System;

namespace ECommerce.Models.Queries.Item
{
    public class SearchItemModel
    {
        public string Name { get; set; }
        public Guid CategoryId { get; set; }
        public int Quantity { get; set; }
        public decimal BuyPrice { get; set; }
    }
}
