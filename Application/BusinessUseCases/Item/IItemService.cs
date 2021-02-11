using ECommerce.Models.BusinessUseCases.Item;
using StoreakApiService.Core.Responses;
using System;
using System.Threading.Tasks;

namespace ECommerce.Application.BusinessUseCases.Item
{
    public interface IItemService
    {
        Task<CustomResponse> Create(CreateItemModel request);
        Task<CustomResponse> Update(Guid id, UpdateItemModel request);
        Task<CustomResponse> Delete(Guid id);
    }
}
