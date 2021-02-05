using ECommerce.Infrastructure.DataModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoreakApiService.Core.Context.Mapping;

namespace ECommerce.Infrastructure.Mapping
{
    public class OrderMap : TrackableMap<OrderDto>
    {
        public override void Configure(EntityTypeBuilder<OrderDto> builder)
        {
            builder.Property(c => c.OrderNo).IsRequired(true).HasColumnName("OrderNo");
            builder.Property(c => c.OrderDate).IsRequired(false).HasColumnName("OrderDate");
            builder.Property(c => c.ShipDate).IsRequired(false).HasColumnName("ShipDate");
            builder.Property(c => c.DeliveryDate).IsRequired(false).HasColumnName("DeliveryDate");
            builder.Property(c => c.OrderStatus).IsRequired(true).HasColumnName("OrderStatus").HasDefaultValue(OrderStatus.New);
            builder.Property(c => c.Total).IsRequired(true).HasColumnName("Total").HasDefaultValue(0);

            base.Configure(builder);
            builder.ToTable("Orders");
        }
    }
}
