using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessObject.Mappings
{
    public class OrderMapConfig : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(o => o.Status).IsRequired();
            builder.HasMany(o => o.Plates).WithMany(p => p.Orders);
            builder.HasOne(o => o.Client).WithMany(c => c.Orders);

            builder.HasOne(o => o.Restaurant).WithMany(r => r.Orders);
        }
    }
}
