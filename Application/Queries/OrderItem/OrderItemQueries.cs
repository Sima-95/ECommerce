using System;
using AutoMapper;
using ECommerce.Infrastructure;
using ECommerce.Infrastructure.DataModel;
using StoreakApiService.Core.Responses;
using System.Threading.Tasks;
using ECommerce.Models.Queries.OrderItem;
using StoreakApiService.Core.Context;
using System.Linq.Dynamic.Core;
using System.Linq;

namespace ECommerce.Application.Queries.OrderItem
{
    public class OrderItemQueries
    {
        private IMapper _mapper;
        private ResponseMessages _responsMessages;
        private UnitOfWork _unitOfWork;

        public OrderItemQueries(IMapper mapper, UnitOfWork unitOfWork, IResponseMessages responsMessages)
        {
            _mapper = mapper;
            _responsMessages = responsMessages as ResponseMessages;
            _unitOfWork = unitOfWork;
        }

        public async Task<CustomResponse> Get(Guid id)
        {
            OrderItemDto orderItem = await _unitOfWork.OrderItemRepository.FindAsync(id);
            if (orderItem == null)
                return _responsMessages.OrderItemNotFound;

            GetOrderItemModel model = _mapper.Map<GetOrderItemModel>(orderItem);

            return new OkResponse(model);
        }

        public async Task<CustomResponse> OrderItemsReport(PagingParams pagingParams, DateTime from, DateTime to)
        {
            try
            {
                var result = await _unitOfWork.OrderItemRepository
                                        .GetAll()
                                        .Where(x => x.CreatedDate.Date >= from.Date && x.CreatedDate.Date <= to.Date)
                                        .GroupBy(x => new { x.CreatedDate.Date, x.ItemId })
                                        .Select(x => new OrderItemReport
                                        {
                                            CreatedDate = x.Key.Date,
                                            ItemId = x.Key.ItemId,
                                            Quantity = x.Sum(y => y.Quantity),
                                            Total = x.Sum(y => y.Total)
                                        })
                                        .GetPagedAsync<OrderItemReport, OrderItemReportModel>(pagingParams, _mapper);
                return new OkResponse(result);
            }
            catch (Exception e)
            {
                return new OkResponse(0);
            }
        }
    }
}
