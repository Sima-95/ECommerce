using ECommerce.Application.BusinessUseCases.Item;
using ECommerce.Application.Queries.Item;
using ECommerce.Infrastructure;
using ECommerce.Models.BusinessUseCases.Item;
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
    [ControllerDocumentation("a9d1f93f-fd61-40aa-8039-d677fc4c69ea", "Item Controller.")]
    public class ItemController : StoreakController
    {
        private IItemService IItemService { get; }
        private ItemQueries ItemQueries { get; }
        private ResponseMessages ResponsMessages { get; }

        public ItemController(IItemService iItemService, ItemQueries itemQueries, IResponseMessages responsMessages)
        {
            IItemService = iItemService;
            ItemQueries = itemQueries;
            ResponsMessages = responsMessages as ResponseMessages;
        }

        [Authorize]
        [Route("api/v1/items/{id}")]
        [HttpGet]
        [ApiDocumentation("fc636230-e90b-406a-bd35-58a15b3bd873", "Get Item by id.")]
        public async Task<ActionResult> Get(Guid id)
        {
            return await ItemQueries.Get(id);
        }

        [Authorize]
        [Route("api/v1/items/paging")]
        [HttpGet]
        [ApiDocumentation("908730a0-89d5-4c0f-9c16-ffb3e4045568", "Get all items.")]
        public async Task<ActionResult> Search([FromQuery] PagingParams pagingParams, [FromQuery] string filter = null)
        {
            return await ItemQueries.Search(pagingParams,filter);
        }

        [Authorize]
        [ClaimRequirement(ClaimTypes.Role, "StoreAdmin")]
        [Route("api/v1/items")]
        [HttpPost]
        [ApiDocumentation("a19d0fe8-4bf9-4c0c-934d-37f9a8cbb4b6", "Create new item.")]
        public async Task<ActionResult> Create([FromBody] CreateItemModel request)
        {
            return await IItemService.Create(request);
        }

        [Authorize]
        [ClaimRequirement(ClaimTypes.Role, "StoreAdmin")]
        [Route("api/v1/items/{id}")]
        [HttpPut]
        [ApiDocumentation("a19d0fe8-4bf9-4c0c-934d-37f9a8cbb4b6", "Update an item by id.")]
        public async Task<ActionResult> Update(Guid id, [FromBody] UpdateItemModel request)
        {
            return await IItemService.Update(id, request);
        }

        [Authorize]
        [ClaimRequirement(ClaimTypes.Role, "StoreAdmin")]
        [Route("api/v1/items/{id}")]
        [HttpDelete]
        [ApiDocumentation("a19d0fe8-4bf9-4c0c-934d-37f9a8cbb4b6", "Delete an item by id.")]
        public async Task<ActionResult> Delete(Guid id)
        {
            return await IItemService.Delete(id);
        }
    }
}
