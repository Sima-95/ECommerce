using ECommerce.Models.BusinessUseCases.Category;
using StoreakApiService.Core.Responses;
using System;
using System.Threading.Tasks;

namespace ECommerce.Application.BusinessUseCases.Category
{
    public interface ICategoryService
    {
        Task<CustomResponse> Create(CreateCategoryModel request);
        Task<CustomResponse> Update(Guid id, UpdateCategoryModel request);
        Task<CustomResponse> Delete(Guid id);
    }
}
