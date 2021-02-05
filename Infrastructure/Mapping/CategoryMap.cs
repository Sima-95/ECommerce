using ECommerce.Infrastructure.DataModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoreakApiService.Core.Context.Mapping;

namespace ECommerce.Infrastructure.Mapping
{
    public class CategoryMap : TrackableMap<CategoryDto>
    {
        public override void Configure(EntityTypeBuilder<CategoryDto> builder)
        {
            builder.Property(c => c.Name).IsRequired(true).HasColumnName("Name");
            builder.Property(c => c.Description).IsRequired(false).HasColumnName("Description");
            builder.Property(c => c.Parent).IsRequired(false).HasColumnName("Parent");

            base.Configure(builder);
            builder.ToTable("Categories");
        }
    }
}
