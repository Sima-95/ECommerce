using System;
using System.Collections.Generic;

namespace ECommerce.Models.Queries.Category
{
    public class GetAllCategoryModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<GetAllCategoryModel> _Children { get; set; }
    }
}
