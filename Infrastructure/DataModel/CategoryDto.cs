﻿using StoreakApiService.Core.Context.DataModel;
using System;
using System.Collections.Generic;

namespace ECommerce.Infrastructure.DataModel
{
    public class CategoryDto : TrackableDto
    {
        public CategoryDto()
        {
            Items = new HashSet<ItemDto>();
            _Children = new HashSet<CategoryDto>();
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public Guid? Parent { get; set; }
        public virtual ICollection<ItemDto> Items { get; set; }
        public virtual CategoryDto _Parent { get; set; }
        public virtual ICollection<CategoryDto> _Children { get; set; }
    }
}
