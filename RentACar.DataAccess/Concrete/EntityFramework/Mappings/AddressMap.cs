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
    public class AddressMap : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("Addresses");

            builder.HasKey(a => a.ID);
            builder.Property(a => a.ID).UseIdentityColumn();
            builder.Property(a => a.ID).IsRequired();

            builder.Property(a => a.FullAddress).IsRequired();
            builder.Property(a => a.FullAddress).HasMaxLength(250);

            builder.Property(a => a.CreationDate).HasColumnType("timestamp without time zone");

            builder.HasOne(mc => mc.District).WithMany(m => m.Addresses).HasForeignKey(mc => mc.DistrictID);

            builder.HasData(new Address
            {
                ID = 1,
                FullAddress = "ali kuşçu mah",
                Status = true,
                CreationDate = DateTime.Now,
                DistrictID=1,
                TownId=1,
                CountryID=1,
                CityId=1,
                PostalCode="000A4"
            }, new Address
            {
                ID = 2,
                FullAddress = "misvak sok mah",
                Status = true,
                CreationDate = DateTime.Now,
                DistrictID = 1,
                TownId = 1,
                CountryID = 1,
                CityId = 1,
                PostalCode = "582AO"
            });
        }
    }
}
