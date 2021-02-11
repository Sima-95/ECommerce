using ECommerce.Models.BusinessUseCases.OrderItem;
using StoreakApiService.Core.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Application.BusinessUseCases.OrderItem
{
    public interface IOrderItemService
    {
        Task<CustomResponse> Update(Guid id, UpdateOrderItemModel request);
        Task<CustomResponse> Delete(Guid id);
    }
}
