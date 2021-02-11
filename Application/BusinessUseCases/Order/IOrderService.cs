using ECommerce.Models.BusinessUseCases.Order;
using StoreakApiService.Core.Responses;
using System;
using System.Threading.Tasks;

namespace ECommerce.Application.BusinessUseCases.Order
{
    public interface IOrderService
    {
        Task<CustomResponse> Create(CreateOrderModel request);
        Task<CustomResponse> Cancel(Guid id, string user);
        Task<CustomResponse> Order(Guid id, string user);
        Task<CustomResponse> Ship(Guid id);
        Task<CustomResponse> Deliver(Guid id);
        Task<CustomResponse> Delete(Guid id);
    }
}
