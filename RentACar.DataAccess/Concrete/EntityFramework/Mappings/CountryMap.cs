using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentACar.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.DataAccess.Concrete.EntityFramework.Mappings
{
    public class CountryMap : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.ToTable("Countries");

            builder.HasKey(c => c.ID);
            builder.Property(c => c.ID).IsRequired();
            builder.Property(c => c.ID).UseIdentityColumn();

            builder.Property(c => c.Name).IsRequired();
            builder.Property(c => c.Name).HasMaxLength(50);

            builder.HasData(new Country
            {
                ID = 1,
                Name = "TÜRKİYE"
            }, new Country
            {
                ID = 2,
                Name = "AMERİKA"
            });
        }
    }
}
