using ECommerce.Application.BusinessUseCases.OrderItem;
using ECommerce.Application.Queries.OrderItem;
using ECommerce.Infrastructure;
using ECommerce.Models.BusinessUseCases.OrderItem;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StoreakApiService.Core.Attributes;
using StoreakApiService.Core.Context;
using StoreakApiService.Core.Controllers;
using StoreakApiService.Core.Responses;
using StoreakApiService.Core.Security;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ECommerce.Controllers
{
    [ControllerDocumentation("a9d1f93f-fd61-40aa-8039-d677fc4c69ea", "Order Item Controller.")]
    public class OrderItemController : StoreakController
    {
        private IOrderItemService IOrderItemService { get; }
        private OrderItemQueries OrderItemQueries { get; }
        private ResponseMessages ResponsMessages { get; }

        public OrderItemController(IOrderItemService iOrderItemService, OrderItemQueries orderItemQueries, IResponseMessages responsMessages)
        {
            IOrderItemService = iOrderItemService;
            OrderItemQueries = orderItemQueries;
            ResponsMessages = responsMessages as ResponseMessages;
        }

        [Authorize]
        [Route("api/v1/orderItems/{id}")]
        [HttpGet]
        [ApiDocumentation("fc636230-e90b-406a-bd35-58a15b3bd873", "Get Order Item by id.")]
        public async Task<ActionResult> Get(Guid id)
        {
            return await OrderItemQueries.Get(id);
        }

        [Authorize]
        [ClaimRequirement(ClaimTypes.Role, "StoreAdmin")]
        [Route("api/v1/orderItems/{id}")]
        [HttpPut]
        [ApiDocumentation("a19d0fe8-4bf9-4c0c-934d-37f9a8cbb4b6", "Update an order item by id.")]
        public async Task<ActionResult> Update(Guid id, [FromBody] UpdateOrderItemModel request)
        {
            return await IOrderItemService.Update(id, request);
        }

        [Authorize]
        [ClaimRequirement(ClaimTypes.Role, "StoreAdmin")]
        [Route("api/v1/orderItems/{id}")]
        [HttpDelete]
        [ApiDocumentation("a19d0fe8-4bf9-4c0c-934d-37f9a8cbb4b6", "Delete an item by id.")]
        public async Task<ActionResult> Delete(Guid id)
        {
            return await IOrderItemService.Delete(id);
        }

        [Authorize]
        [Route("api/v1/orderItems/sellReport")]
        [HttpGet]
        [ApiDocumentation("fc636230-e90b-406a-bd35-58a15b3bd873", "Get Order Item Sells Report.")]
        public async Task<ActionResult> OrderItemReport([FromQuery] PagingParams pagingParams, [FromQuery] DateTime fromDate, [FromQuery] DateTime toDate)
        {
            return await OrderItemQueries.OrderItemsReport(pagingParams, fromDate, toDate);
        }
    }
}
