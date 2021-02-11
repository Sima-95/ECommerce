using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Models.Queries.Item
{
    public class GetItemModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid CategoryId { get; set; }
        public int Quantity { get; set; }
        public decimal BuyPrice { get; set; }
        public decimal? SellPrice { get; set; }
        public bool SellAvaialable { get; set; }
        public string Picture { get; set; }
        public decimal Ranking { get; set; }
        public string Note { get; set; }
    }
}
