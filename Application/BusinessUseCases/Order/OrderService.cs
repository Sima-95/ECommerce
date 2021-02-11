using AutoMapper;
using ECommerce.Infrastructure;
using ECommerce.Infrastructure.DataModel;
using ECommerce.Models.BusinessUseCases.Order;
using StoreakApiService.Core.Responses;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Application.BusinessUseCases.Order
{
    public class OrderService : IOrderService
    {
        private IMapper _mapper;
        private ResponseMessages _responsMessages;
        private UnitOfWork _unitOfWork;

        public OrderService(IMapper mapper, UnitOfWork unitOfWork, IResponseMessages responsMessages)
        {
            _mapper = mapper;
            _responsMessages = responsMessages as ResponseMessages;
            _unitOfWork = unitOfWork;
        }

        public async Task<CustomResponse> Create(CreateOrderModel request)
        {
            //Create Order 
            OrderDto order = _mapper.Map<OrderDto>(request);

            order.OrderNo = (_unitOfWork.OrderRepository
                .GetAll()
                .OrderByDescending(x => x.OrderNo)
                .Select(x => x.OrderNo)
                .FirstOrDefault()) + 1;
            order.OrderStatus = OrderStatus.New;
            order.Total = 0;
            _unitOfWork.OrderRepository.Add(order);
            await _unitOfWork.SaveChangesAsync();

            decimal total = 0;

            //Create Order Items
            foreach (var orderItem in order.OrderItems)
            {
                OrderItemDto orderItemDto = _mapper.Map<OrderItemDto>(orderItem);
                //Check item
                ItemDto item = _unitOfWork.ItemRepository.Find(orderItemDto.ItemId);

                if (item == null)
                {
                    return _responsMessages.ItemNotFound;
                }

                if(orderItemDto.Quantity > item.Quantity)
                    return _responsMessages.InvalidOrderItemQuantity;

                orderItemDto.PricePerUnit = item.SellAvaialable ? (decimal)item.SellPrice : item.BuyPrice;
                orderItemDto.Total = orderItemDto.PricePerUnit * orderItemDto.Quantity;
                orderItemDto.OrderId = order.Id;

                total += orderItemDto.Total;
                await _unitOfWork.SaveChangesAsync();
            }

            //update order total
            order.Total = total;
            await _unitOfWork.SaveChangesAsync();

            return new OkResponse(order.Id);
        }

        public async Task<CustomResponse> Delete(Guid id)
        {
            OrderDto orderDto = _unitOfWork.OrderRepository.Find(id);

            if (orderDto == null)
            {
                return _responsMessages.OrderNotFound;
            }

            //Check if order has items
            if (_unitOfWork.OrderItemRepository.GetAll().Where(x => x.OrderId == orderDto.Id).Count() > 0)
                return _responsMessages.OrderHasRelatedRecords;

            _unitOfWork.OrderRepository.Remove(orderDto);
            await _unitOfWork.SaveChangesAsync();
            return _responsMessages.OrderDeletedSuccessfully;
        }

        public async Task<CustomResponse> Cancel(Guid id, string user)
        {
            OrderDto orderDto = _unitOfWork.OrderRepository.Find(id);

            if (orderDto == null)
            {
                return _responsMessages.OrderNotFound;
            }
            if (orderDto.OrderStatus != OrderStatus.New && orderDto.OrderStatus != OrderStatus.Ordered)
                return _responsMessages.InvalidOperation;

            if (orderDto.CreatedBy != user)
                return _responsMessages.InvalidOperation;

            orderDto.OrderStatus = OrderStatus.Cancelled;
            await _unitOfWork.SaveChangesAsync();
            return _responsMessages.OrderCancelledSuccessfully;
        }

        public async Task<CustomResponse> Order(Guid id, string user)
        {
            OrderDto orderDto = _unitOfWork.OrderRepository.Find(id);

            if (orderDto == null)
            {
                return _responsMessages.OrderNotFound;
            }
            if(orderDto.OrderStatus != OrderStatus.New)
                return _responsMessages.InvalidOperation;

            if (orderDto.CreatedBy != user)
                return _responsMessages.InvalidOperation;

            orderDto.OrderStatus = OrderStatus.Ordered;
            orderDto.OrderDate = DateTime.Now;

            await _unitOfWork.SaveChangesAsync();
            return _responsMessages.OrderOrderedSuccessfully;
        }

        public async Task<CustomResponse> Ship(Guid id)
        {
            //Update Order Status
            OrderDto orderDto = _unitOfWork.OrderRepository.Find(id);

            if (orderDto == null)
            {
                return _responsMessages.OrderNotFound;
            }
            if (orderDto.OrderStatus != OrderStatus.Ordered)
                return _responsMessages.InvalidOperation;

            orderDto.OrderStatus = OrderStatus.Shipped;
            orderDto.ShipDate = DateTime.Now;

            await _unitOfWork.SaveChangesAsync();

            //Decrese Item Qunatity
            var orderItems = _unitOfWork.OrderItemRepository.GetAll().Where(x => x.OrderId == orderDto.Id);
            foreach (OrderItemDto orderItem in orderItems) {
                ItemDto item = _unitOfWork.ItemRepository.Find(orderItem.ItemId);
                if (item == null)
                {
                    return _responsMessages.ItemNotFound;
                }
                if(item.Quantity > orderItem.Quantity)
                    return _responsMessages.InvalidQunatity;

                item.Quantity -= orderItem.Quantity;
                await _unitOfWork.SaveChangesAsync();
            }
            return _responsMessages.OrderShippedSuccessfully;
        }

        public async Task<CustomResponse> Deliver(Guid id)
        {
            OrderDto orderDto = _unitOfWork.OrderRepository.Find(id);

            if (orderDto == null)
            {
                return _responsMessages.OrderNotFound;
            }
            if (orderDto.OrderStatus != OrderStatus.Shipped)
                return _responsMessages.InvalidOperation;

            orderDto.OrderStatus = OrderStatus.Delivered;
            orderDto.DeliveryDate = DateTime.Now;

            await _unitOfWork.SaveChangesAsync();
            return _responsMessages.OrderDeliveredSuccessfully;
        }
    }
}
