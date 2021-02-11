using System;
using System.Linq;
using AutoMapper;
using ECommerce.Infrastructure;
using ECommerce.Infrastructure.DataModel;
using StoreakApiService.Core.Context;
using StoreakApiService.Core.Responses;
using System.Threading.Tasks;
using ECommerce.Models.Queries.Order;
using System.Linq.Dynamic.Core;

namespace ECommerce.Application.Queries.Order
{
    public class OrderQueries
    {
        private IMapper _mapper;
        private ResponseMessages _responsMessages;
        private UnitOfWork _unitOfWork;

        public OrderQueries(IMapper mapper, UnitOfWork unitOfWork, IResponseMessages responsMessages)
        {
            _mapper = mapper;
            _responsMessages = responsMessages as ResponseMessages;
            _unitOfWork = unitOfWork;
        }

        public async Task<CustomResponse> Get(Guid id)
        {
            OrderDto order = await _unitOfWork.OrderRepository.FindAsync(id);
            if (order == null)
                return _responsMessages.OrderNotFound;

            GetOrderModel model = _mapper.Map<GetOrderModel>(order);

            return new OkResponse(model);
        }

        public async Task<CustomResponse> Search(PagingParams pagingParams, string filter)
        {
            var result = await _unitOfWork.OrderRepository
                                    .GetAll()
                                    .Where(Helpers.FilterHelper.filterJsonToString(filter))
                                    .GetPagedAsync<OrderDto, SearchOrderModel>(pagingParams, _mapper);
            return new OkResponse(result);
        }

        public async Task<CustomResponse> DailyReport(PagingParams pagingParams, DateTime from, DateTime to)
        {            
            var result = await _unitOfWork.OrderRepository
                                    .GetAll()
                                    .Where(x => x.CreatedDate.Date >= from.Date && x.CreatedDate.Date <= to.Date)
                                    .GroupBy(x => x.CreatedDate.Date)
                                    .Select(x => new OrderReport
                                    {
                                        CreatedDate = x.Key,
                                        TotalOrders = x.Count(),
                                        CancelledOrders = x.Where(y => y.OrderStatus == OrderStatus.Cancelled).Count()
                                    })
                                    .GetPagedAsync<OrderReport, OrderReportModel>(pagingParams, _mapper);
            return new OkResponse(result);
        }
    }
}
