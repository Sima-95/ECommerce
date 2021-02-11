using AutoMapper;
using ECommerce.Infrastructure;
using ECommerce.Infrastructure.DataModel;
using ECommerce.Models.BusinessUseCases.Category;
using StoreakApiService.Core.Responses;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Application.BusinessUseCases.Category
{
    public class CategoryService : ICategoryService
    {
        private IMapper _mapper;
        private ResponseMessages _responsMessages;
        private UnitOfWork _unitOfWork;

        public CategoryService(IMapper mapper, UnitOfWork unitOfWork, IResponseMessages responsMessages)
        {
            _mapper = mapper;
            _responsMessages = responsMessages as ResponseMessages;
            _unitOfWork = unitOfWork;
        }

        public async Task<CustomResponse> Create(CreateCategoryModel request)
        {
            try
            {
                CategoryDto category = _mapper.Map<CategoryDto>(request);
                if (category.Parent != null)
                {
                    CategoryDto parent = _unitOfWork.CategoryRepository.Find(category.Parent);
                    if (parent == null)
                        return _responsMessages.CategoryParentNotFound;
                }
                _unitOfWork.CategoryRepository.Add(category);
                await _unitOfWork.SaveChangesAsync();
                return new OkResponse(category.Id);
            }
            catch (Exception e)
            {
                return new OkResponse(e.Message);
            }
        }

        public async Task<CustomResponse> Delete(Guid id)
        {
            CategoryDto categoryDto = _unitOfWork.CategoryRepository.Find(id);

            if (categoryDto == null)
            {
                return _responsMessages.CategoryNotFound;
            }

            //Check if category has items
            if (_unitOfWork.ItemRepository.GetAll().Where(x => x.CategoryId == categoryDto.Id).Count() > 0)
                return _responsMessages.CategoryHasRelatedRecords;

            //Check if category has categories
            if (_unitOfWork.CategoryRepository.GetAll().Where(x => x.Parent == categoryDto.Id).Count() > 0)
                return _responsMessages.CategoryHasRelatedRecords;

            _unitOfWork.CategoryRepository.Remove(categoryDto);
            await _unitOfWork.SaveChangesAsync();
            return _responsMessages.CategoryDeletedSuccessfully;
        }

        public async Task<CustomResponse> Update(Guid id, UpdateCategoryModel UpdateRequest)
        {
            CategoryDto categoryDto = _unitOfWork.CategoryRepository.Find(id);

            if (categoryDto == null)
            {
                return _responsMessages.CategoryNotFound;
            }

            categoryDto.Name = UpdateRequest.Name;
            categoryDto.Description = UpdateRequest.Description;
            categoryDto.Parent = UpdateRequest.Parent;

            if (categoryDto.Parent != null)
            {
                CategoryDto parent = _unitOfWork.CategoryRepository.Find(categoryDto.Parent);
                if(parent == null)
                    return _responsMessages.CategoryParentNotFound;
            }
            await _unitOfWork.SaveChangesAsync();
            return _responsMessages.CategoryUpdatedSuccessfully;
        }
    }
}
