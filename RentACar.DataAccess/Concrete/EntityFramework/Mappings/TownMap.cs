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
    public class TownMap : IEntityTypeConfiguration<Town>
    {
        public void Configure(EntityTypeBuilder<Town> builder)
        {
            builder.ToTable("Towns");

            builder.HasKey(ct => ct.ID);
            builder.Property(ct => ct.ID).UseIdentityColumn();
            builder.Property(ct => ct.ID).IsRequired();

            builder.Property(ct => ct.Name).IsRequired();
            builder.Property(ct => ct.Name).HasMaxLength(50);

            builder.HasOne(d => d.City).WithMany(t => t.Towns).HasForeignKey(d => d.CityID);

            builder.HasData(new Town
            {
                ID = 1,
                Name = "Sultangazi",
                CityID = 1

            }, new Town
            {
                ID = 2,
                Name = "Fatih",
                CityID = 1
            });

        }
    }
}
