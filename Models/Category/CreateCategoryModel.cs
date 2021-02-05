using StoreakApiService.Core.Attributes;
using System;

namespace ECommerce.Models.Category
{
    public class CreateCategoryModel
    {
        [RequiredValue(ErrorMessage = "CategoryNameRequired")]
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid? Parent { get; set; }
    }
}
