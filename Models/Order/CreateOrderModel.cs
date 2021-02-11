using ECommerce.Models.BusinessUseCases.OrderItem;
using System.Collections.Generic;

namespace ECommerce.Models.BusinessUseCases.Order
{
    public class CreateOrderModel
    {
        public ICollection<CreateOrderItemModel> OrderItems { get; set; }
    }
}
