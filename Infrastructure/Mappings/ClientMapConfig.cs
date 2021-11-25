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
    public class ClientMapConfig : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.Property(c => c.Name).IsRequired().IsUnicode(false).HasMaxLength(70);
            builder.Property(c => c.Cpf).IsRequired().IsUnicode(false).IsFixedLength().HasMaxLength(11);
            builder.HasIndex(c => c.Cpf).IsUnique();
            builder.Property(c => c.BirthDate).IsRequired();
            builder.Property(c => c.Cep).IsRequired().IsFixedLength().HasMaxLength(8);
            builder.Property(c => c.PhoneNumber).IsRequired().HasMaxLength(13).IsUnicode();
        }
    }
}
