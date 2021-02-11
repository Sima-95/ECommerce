using ECommerce.Infrastructure.DataModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoreakApiService.Core.Context.Mapping;

namespace ECommerce.Infrastructure.Mapping
{
    public class ItemMap : TrackableMap<ItemDto>
    {
        public override void Configure(EntityTypeBuilder<ItemDto> builder)
        {
            builder.Property(c => c.Name).IsRequired(true).HasColumnName("Name");
            builder.Property(c => c.Description).IsRequired(false).HasColumnName("Description");
            builder.Property(c => c.CategoryId).IsRequired(true).HasColumnName("CategoryId");
            builder.Property(c => c.Quantity).IsRequired(true).HasColumnName("Quantity").HasDefaultValue(0);
            builder.Property(c => c.BuyPrice).IsRequired(true).HasColumnName("BuyPrice");
            builder.Property(c => c.SellPrice).IsRequired(false).HasColumnName("SellPrice");
            builder.Property(c => c.SellAvaialable).IsRequired(true).HasColumnName("SellAvaialable").HasDefaultValue(false);
            builder.Property(c => c.Picture).IsRequired(false).HasColumnName("Picture");
            builder.Property(c => c.Ranking).IsRequired(true).HasColumnName("Ranking").HasDefaultValue(0);
            builder.Property(c => c.Note).IsRequired(false).HasColumnName("Note");
            builder.HasOne(d => d.Category)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.CategoryId);

            base.Configure(builder);
            builder.ToTable("Items");
        }
    }
}
