using ECommerce.Infrastructure.DataModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoreakApiService.Core.Context.Mapping;

namespace ECommerce.Infrastructure.Mapping
{
    public class OrderItemMap : TrackableMap<OrderItemDto>
    {
        public override void Configure(EntityTypeBuilder<OrderItemDto> builder)
        {
            builder.Property(c => c.OrderId).IsRequired(true).HasColumnName("OrderId");
            builder.Property(c => c.ItemId).IsRequired(true).HasColumnName("ItemId");
            builder.Property(c => c.Quantity).IsRequired(true).HasColumnName("Quantity").HasDefaultValue(1);
            builder.Property(c => c.PricePerUnit).IsRequired(true).HasColumnName("PricePerUnit");
            builder.Property(c => c.Total).IsRequired(true).HasColumnName("Total");

            base.Configure(builder);
            builder.ToTable("OrderItems");
        }
    }
}
