using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Models.BusinessUseCases.OrderItem
{
    public class CreateOrderItemModel
    {
        public Guid ItemId { get; set; }
        public int Quantity { get; set; }
    }
}
