using ECommerce.Models.Queries.Item;
using System;
using System.Collections.Generic;

namespace ECommerce.Models.Queries.Category
{
    public class GetCategoryModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid? Parent { get; set; }
        public virtual ICollection<GetItemModel> Items { get; set; }
        public virtual ICollection<GetAllCategoryModel> _Children { get; set; }
    }
}
