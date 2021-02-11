using ECommerce.Infrastructure;
using ECommerce.Infrastructure.DataModel;
using StoreakApiService.Core.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Application
{
    public class UnitOfWork
    {
        private ModelContext _context;
        public UnitOfWork(ModelContext context)
        {
            _context = context;
        }

        public GenericRepository<CategoryDto> CategoryRepository
        {
            get
            {
                return new GenericRepository<CategoryDto>(_context.Categories);
            }
        }

        public GenericRepository<ItemDto> ItemRepository
        {
            get
            {
                return new GenericRepository<ItemDto>(_context.Items);
            }
        }

        public GenericRepository<OrderDto> OrderRepository
        {
            get
            {
                return new GenericRepository<OrderDto>(_context.Orders);
            }
        }

        public GenericRepository<OrderItemDto> OrderItemRepository
        {
            get
            {
                return new GenericRepository<OrderItemDto>(_context.OrderItems);
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
