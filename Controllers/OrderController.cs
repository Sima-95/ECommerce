using StoreakApiService.Core.Attributes;
using StoreakApiService.Core.Controllers;
using System;
using System.Threading.Tasks;
using ECommerce.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StoreakApiService.Core.Context;
using StoreakApiService.Core.Responses;
using StoreakApiService.Core.Security;
using System.Security.Claims;
using ECommerce.Application.BusinessUseCases.Order;
using ECommerce.Application.Queries.Order;
using ECommerce.Models.BusinessUseCases.Order;

namespace ECommerce.Controllers
{
    [ControllerDocumentation("a9d1f93f-fd61-40aa-8039-d677fc4c69ea", "Order Controller.")]
    public class OrderController : StoreakController
    {
        private IOrderService IOrderService { get; }
        private OrderQueries OrderQueries { get; }
        private ResponseMessages ResponsMessages { get; }

        public OrderController(IOrderService iOrderService, OrderQueries orderQueries, IResponseMessages responsMessages)
        {
            IOrderService = iOrderService;
            OrderQueries = orderQueries;
            ResponsMessages = responsMessages as ResponseMessages;
        }

        [Authorize]
        [Route("api/v1/orders/{id}")]
        [HttpGet]
        [ApiDocumentation("fc636230-e90b-406a-bd35-58a15b3bd873", "Get Order by id.")]
        public async Task<ActionResult> Get(Guid id)
        {
            return await OrderQueries.Get(id);
        }

        [Authorize]
        [Route("api/v1/orders/paging")]
        [HttpGet]
        [ApiDocumentation("908730a0-89d5-4c0f-9c16-ffb3e4045568", "Get all orders.")]
        public async Task<ActionResult> Search([FromQuery] PagingParams pagingParams, [FromQuery] string filter = null)
        {
            return await OrderQueries.Search(pagingParams, filter);
        }

        [Authorize]
        [ClaimRequirement(ClaimTypes.Role, "Customer")]
        [Route("api/v1/orders")]
        [HttpPost]
        [ApiDocumentation("a19d0fe8-4bf9-4c0c-934d-37f9a8cbb4b6", "Create new order.")]
        public async Task<ActionResult> Create([FromBody] CreateOrderModel request)
        {
            return await IOrderService.Create(request);
        }

        [Authorize]
        [ClaimRequirement(ClaimTypes.Role, "Customer")]
        [Route("api/v1/orders/cancel/{id}")]
        [HttpPut]
        [ApiDocumentation("a19d0fe8-4bf9-4c0c-934d-37f9a8cbb4b6", "Cancel an order by id.")]
        public async Task<ActionResult> Cancel(Guid id)
        {
            return await IOrderService.Cancel(id, User.Identity.Name);
        }

        [Authorize]
        [ClaimRequirement(ClaimTypes.Role, "Customer")]
        [Route("api/v1/orders/order/{id}")]
        [HttpPut]
        [ApiDocumentation("a19d0fe8-4bf9-4c0c-934d-37f9a8cbb4b6", "Order an order by id.")]
        public async Task<ActionResult> Order(Guid id)
        {
            return await IOrderService.Order(id, User.Identity.Name);
        }

        [Authorize]
        [ClaimRequirement(ClaimTypes.Role, "StoreAdmin")]
        [Route("api/v1/orders/ship/{id}")]
        [HttpPut]
        [ApiDocumentation("a19d0fe8-4bf9-4c0c-934d-37f9a8cbb4b6", "Ship an order by id.")]
        public async Task<ActionResult> Ship(Guid id)
        {
            return await IOrderService.Ship(id);
        }

        [Authorize]
        [ClaimRequirement(ClaimTypes.Role, "StoreAdmin")]
        [Route("api/v1/orders/deliver/{id}")]
        [HttpPut]
        [ApiDocumentation("a19d0fe8-4bf9-4c0c-934d-37f9a8cbb4b6", "Deliver an order by id.")]
        public async Task<ActionResult> Deliver(Guid id)
        {
            return await IOrderService.Deliver(id);
        }

        [Authorize]
        [ClaimRequirement(ClaimTypes.Role, "StoreAdmin")]
        [Route("api/v1/orders/{id}")]
        [HttpDelete]
        [ApiDocumentation("a19d0fe8-4bf9-4c0c-934d-37f9a8cbb4b6", "Delete an order by id.")]
        public async Task<ActionResult> Delete(Guid id)
        {
            return await IOrderService.Delete(id);
        }

        [Authorize]
        [Route("api/v1/orders/dailyReport")]
        [HttpGet]
        [ApiDocumentation("fc636230-e90b-406a-bd35-58a15b3bd873", "Get Daily Order Report.")]
        public async Task<ActionResult> DailyReport([FromQuery] PagingParams pagingParams, [FromQuery] DateTime fromDate, [FromQuery] DateTime toDate)
        {
            return await OrderQueries.DailyReport(pagingParams, fromDate, toDate);
        }
    }
}
