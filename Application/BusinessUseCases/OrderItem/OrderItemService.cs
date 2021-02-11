using AutoMapper;
using ECommerce.Infrastructure;
using ECommerce.Infrastructure.DataModel;
using ECommerce.Models.BusinessUseCases.OrderItem;
using StoreakApiService.Core.Responses;
using System;
using System.Threading.Tasks;

namespace ECommerce.Application.BusinessUseCases.OrderItem
{
    public class OrderItemService : IOrderItemService
    {
        private IMapper _mapper;
        private ResponseMessages _responsMessages;
        private UnitOfWork _unitOfWork;

        public OrderItemService(IMapper mapper, UnitOfWork unitOfWork, IResponseMessages responsMessages)
        {
            _mapper = mapper;
            _responsMessages = responsMessages as ResponseMessages;
            _unitOfWork = unitOfWork;
        }

        public async Task<CustomResponse> Delete(Guid id)
        {
            OrderItemDto orderItemDto = _unitOfWork.OrderItemRepository.Find(id);

            if (orderItemDto == null)
            {
                return _responsMessages.OrderItemNotFound;
            }

            if(orderItemDto.Order.OrderStatus != OrderStatus.New)
                return _responsMessages.InvalidOperation;

            //Update Order
            orderItemDto.Order.Total -= orderItemDto.Total;
            await _unitOfWork.SaveChangesAsync();

            //Delete Order Item
            _unitOfWork.OrderItemRepository.Remove(orderItemDto);
            await _unitOfWork.SaveChangesAsync();
            return _responsMessages.OrderItemDeletedSuccessfully;
        }

        public async Task<CustomResponse> Update(Guid id, UpdateOrderItemModel UpdateRequest)
        {
            OrderItemDto orderItemDto = _unitOfWork.OrderItemRepository.Find(id);

            if (orderItemDto == null)           
                return _responsMessages.OrderItemNotFound;           

            if(orderItemDto.Order.OrderStatus != OrderStatus.New)
                return _responsMessages.InvalidOperation;

            orderItemDto.Order.Total -= orderItemDto.Total;
            orderItemDto.Quantity = UpdateRequest.Quantity;
            orderItemDto.Total = orderItemDto.Quantity * orderItemDto.PricePerUnit;
            orderItemDto.Order.Total += orderItemDto.Total;

            if (orderItemDto.Quantity > orderItemDto.Item.Quantity)
                return _responsMessages.InvalidOrderItemQuantity;

            await _unitOfWork.SaveChangesAsync();
            return _responsMessages.OrderItemQuantityUpdatedSuccessfully;
        }
    }
}
