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
