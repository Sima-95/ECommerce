using System;
using System.Collections.Generic;

namespace ECommerce.Models.Category
{
    public class GetCategoryModel
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public Guid? Parent { get; set; }
        public virtual ICollection<GetCategoryModel> Items { get; set; }
    }
}
