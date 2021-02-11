using AutoMapper;
using ECommerce.Infrastructure;
using ECommerce.Infrastructure.DataModel;
using ECommerce.Models.BusinessUseCases.Item;
using StoreakApiService.Core.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Application.BusinessUseCases.Item
{
    public class ItemService : IItemService
    {
        private IMapper _mapper;
        private ResponseMessages _responsMessages;
        private UnitOfWork _unitOfWork;

        public ItemService(IMapper mapper, UnitOfWork unitOfWork, IResponseMessages responsMessages)
        {
            _mapper = mapper;
            _responsMessages = responsMessages as ResponseMessages;
            _unitOfWork = unitOfWork;
        }

        public async Task<CustomResponse> Create(CreateItemModel request)
        {
            ItemDto item = _mapper.Map<ItemDto>(request);

            //Check for category
            CategoryDto category = _unitOfWork.CategoryRepository.Find(item.CategoryId);
            if (category == null)
                return _responsMessages.CategoryNotFound;

            _unitOfWork.ItemRepository.Add(item);
            await _unitOfWork.SaveChangesAsync();
            return new OkResponse(item.Id);
        }

        public async Task<CustomResponse> Delete(Guid id)
        {
            ItemDto itemDto = _unitOfWork.ItemRepository.Find(id);

            if (itemDto == null)
            {
                return _responsMessages.ItemNotFound;
            }

            //Check if item has orders
            if (_unitOfWork.OrderItemRepository.GetAll().Where(x => x.ItemId == itemDto.Id).Count() > 0)
                return _responsMessages.ItemHasRelatedRecords;

            _unitOfWork.ItemRepository.Remove(itemDto);
            await _unitOfWork.SaveChangesAsync();
            return _responsMessages.ItemDeletedSuccessfully;
        }

        public async Task<CustomResponse> Update(Guid id, UpdateItemModel UpdateRequest)
        {
            ItemDto itemDto = _unitOfWork.ItemRepository.Find(id);

            if (itemDto == null)
            {
                return _responsMessages.ItemNotFound;
            }

            itemDto.Name = UpdateRequest.Name;
            itemDto.Description = UpdateRequest.Description;
            itemDto.CategoryId = UpdateRequest.CategoryId;
            itemDto.Quantity = UpdateRequest.Quantity;
            itemDto.BuyPrice = UpdateRequest.BuyPrice;
            itemDto.SellPrice = UpdateRequest.SellPrice;
            itemDto.SellAvaialable = UpdateRequest.SellAvaialable;
            itemDto.Picture = UpdateRequest.Picture;
            itemDto.Ranking = UpdateRequest.Ranking;
            itemDto.Note = UpdateRequest.Note;

            //Check for category
            CategoryDto category = _unitOfWork.CategoryRepository.Find(itemDto.CategoryId);
            if (category == null)
                return _responsMessages.CategoryNotFound;

            await _unitOfWork.SaveChangesAsync();
            return _responsMessages.ItemUpdatedSuccessfully;
        }
    }
}
