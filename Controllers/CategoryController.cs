using ECommerce.Application.BusinessUseCases.Category;
using ECommerce.Application.Queries.Category;
using ECommerce.Infrastructure;
using ECommerce.Models.BusinessUseCases.Category;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StoreakApiService.Core.Attributes;
using StoreakApiService.Core.Controllers;
using StoreakApiService.Core.Responses;
using StoreakApiService.Core.Security;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ECommerce.Controllers
{
    [ControllerDocumentation("a9d1f93f-fd61-40aa-8039-d677fc4c69ea", "Category Controller.")]
    public class CategoryController : StoreakController
    {
        private ICategoryService ICategoryService { get; }
        private CategoryQueries CategoryQueries { get; }
        private ResponseMessages ResponsMessages { get; }

        public CategoryController(ICategoryService iCategoryService, CategoryQueries categoryQueries, IResponseMessages responsMessages)
        {
            ICategoryService = iCategoryService;
            CategoryQueries = categoryQueries;
            ResponsMessages = responsMessages as ResponseMessages;
        }

        [Authorize]
        [Route("api/v1/categories/{id}")]
        [HttpGet]
        [ApiDocumentation("fc636230-e90b-406a-bd35-58a15b3bd873", "Get Category by id.")]
        public async Task<ActionResult> Get(Guid id)
        {
            return await CategoryQueries.Get(id);
        }

        [Authorize]
        [Route("api/v1/categories")]
        [HttpGet]
        [ApiDocumentation("908730a0-89d5-4c0f-9c16-ffb3e4045568", "Get all categories.")]
        public async Task<ActionResult> GetAll()
        {
            return await CategoryQueries.GetAll();
        }

        [Authorize]
        [ClaimRequirement(ClaimTypes.Role, "StoreAdmin")]
        [Route("api/v1/categories")]
        [HttpPost]
        [ApiDocumentation("a19d0fe8-4bf9-4c0c-934d-37f9a8cbb4b6", "Create new category.")]
        public async Task<ActionResult> Create([FromBody] CreateCategoryModel request)
        {
            return await ICategoryService.Create(request);
        }

        [Authorize]
        [ClaimRequirement(ClaimTypes.Role, "StoreAdmin")]
        [Route("api/v1/categories/{id}")]
        [HttpPut]
        [ApiDocumentation("a19d0fe8-4bf9-4c0c-934d-37f9a8cbb4b6", "Update a category by id.")]
        public async Task<ActionResult> Update(Guid id, [FromBody] UpdateCategoryModel request)
        {
            return await ICategoryService.Update(id, request);
        }

        [Authorize]
        [ClaimRequirement(ClaimTypes.Role, "StoreAdmin")]
        [Route("api/v1/categories/{id}")]
        [HttpDelete]
        [ApiDocumentation("a19d0fe8-4bf9-4c0c-934d-37f9a8cbb4b6", "Delete a category by id.")]
        public async Task<ActionResult> Delete(Guid id)
        {
            return await ICategoryService.Delete(id);
        }
    }
}
