using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Mappings
{
    public class RestaurantMapConfig : IEntityTypeConfiguration<Restaurant>
    {
        public void Configure(EntityTypeBuilder<Restaurant> builder)
        {
            builder.Property(r => r.Name).IsUnicode(false).HasMaxLength(70);
            builder.Property(r => r.PhoneNumber).IsRequired().HasMaxLength(13).IsUnicode();
            builder.Property(r => r.Cnpj).IsRequired().IsUnicode(false).HasMaxLength(14);
        }
    }
}
