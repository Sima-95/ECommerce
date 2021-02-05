using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using ECommerce.Infrastructure.DataModel;
using ECommerce.Infrastructure.Mapping;
using StoreakApiService.Core.Context;

namespace ECommerce.Infrastructure
{
    public class ModelContext : StoreDbContext
    {
        public ModelContext(IHttpContextAccessor accessor)
            : base(accessor)
        {
        }

        public virtual DbSet<CategoryDto> Categories { get; set; }
        public virtual DbSet<ItemDto> Items { get; set; }
        public virtual DbSet<OrderDto> Orders { get; set; }
        public virtual DbSet<OrderItemDto> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryMap());
            modelBuilder.ApplyConfiguration(new ItemMap());
            modelBuilder.ApplyConfiguration(new OrderMap());
            modelBuilder.ApplyConfiguration(new OrderItemMap());

            modelBuilder.Entity<CategoryDto>().HasQueryFilter(x =>
               EF.Property<long>(x, "StoreId") == Client.StoreId);
            modelBuilder.Entity<ItemDto>().HasQueryFilter(x =>
               EF.Property<long>(x, "StoreId") == Client.StoreId);
            modelBuilder.Entity<OrderDto>().HasQueryFilter(x =>
               EF.Property<long>(x, "StoreId") == Client.StoreId);
            modelBuilder.Entity<OrderItemDto>().HasQueryFilter(x =>
               EF.Property<long>(x, "StoreId") == Client.StoreId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
