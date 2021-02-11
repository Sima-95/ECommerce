using AutoMapper;
using ECommerce.Infrastructure;
using ECommerce.Infrastructure.DataModel;
using ECommerce.Models.Queries.Category;
using Microsoft.EntityFrameworkCore;
using StoreakApiService.Core.Context;
using StoreakApiService.Core.Responses;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Application.Queries.Category
{
    public class CategoryQueries
    {
        private IMapper _mapper;
        private ResponseMessages _responsMessages;
        private UnitOfWork _unitOfWork;

        public CategoryQueries(IMapper mapper, UnitOfWork unitOfWork, IResponseMessages responsMessages)
        {
            _mapper = mapper;
            _responsMessages = responsMessages as ResponseMessages;
            _unitOfWork = unitOfWork;
        }

        public async Task<CustomResponse> Get(Guid id)
        {
            CategoryDto category = await _unitOfWork.CategoryRepository.FindAsync(id);
            if (category == null)
                return _responsMessages.CategoryNotFound;

            GetCategoryModel model = _mapper.Map<GetCategoryModel>(category);

            return new OkResponse(model);
        }

        public async Task<CustomResponse> GetAll()
        {
            PagingParams pagingParams = new PagingParams();
            pagingParams.CurrentPage = 1;
            pagingParams.PageSize = Int32.MaxValue;
            var result = await _unitOfWork.CategoryRepository
                                    .GetAll()
                                    .Where(c => c.Parent == null)
                                    .Include(c => c._Children)
                                    .ThenInclude(c => c._Children)
                                    .ThenInclude(c => c._Children)
                                    .GetPagedAsync<CategoryDto, GetAllCategoryModel>(pagingParams, _mapper);
            return new OkResponse(result);
        }
    }
}
