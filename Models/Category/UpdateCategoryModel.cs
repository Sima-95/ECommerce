using StoreakApiService.Core.Attributes;
using System;

namespace ECommerce.Models.BusinessUseCases.Category
{
    public class UpdateCategoryModel
    {
        [RequiredValue(ErrorMessage = "CategoryNameRequired")]
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid? Parent { get; set; }
    }
}
