using ECommerce.Models.Queries.Category;
using StoreakApiService.Core.Attributes;
using System;

namespace ECommerce.Models.BusinessUseCases.Category
{
    public class CreateCategoryModel
    {
        [RequiredValue(ErrorMessage = "CategoryNameRequired")]
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid? Parent { get; set; }
        public virtual GetCategoryModel _Parent { get; set; }
    }
}
