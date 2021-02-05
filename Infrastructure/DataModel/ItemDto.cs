using StoreakApiService.Core.Context.DataModel;
using System;
using System.Collections.Generic;

namespace ECommerce.Infrastructure.DataModel
{
    public class ItemDto : TrackableDto
    {
        public ItemDto()
        {
            OrderItems = new HashSet<OrderItemDto>();
        }
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

        public virtual CategoryDto Category { get; set; }
        public virtual ICollection<OrderItemDto> OrderItems { get; set; }
    }
}
