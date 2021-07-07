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
    public class CityMap : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.ToTable("Cities");

            builder.HasKey(c => c.ID);
            builder.Property(c => c.ID).IsRequired();
            builder.Property(c => c.ID).UseIdentityColumn();

            builder.Property(c => c.Name).IsRequired();
            builder.Property(c => c.Name).HasMaxLength(50);

            builder.HasOne(d => d.Country).WithMany(t => t.Cities).HasForeignKey(d => d.CountryID);

            builder.HasData(new City
            {
                ID = 1,
                Name = "İstanbul",
                CountryID=1
            }, new City
            {
                ID = 2,
                Name = "Ankara",
                CountryID = 1
            });
        }
    }
}
