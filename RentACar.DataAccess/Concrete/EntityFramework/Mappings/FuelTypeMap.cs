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
    public class FuelTypeMap : IEntityTypeConfiguration<FuelType>
    {
        public void Configure(EntityTypeBuilder<FuelType> builder)
        {
            builder.ToTable("FuelTypes");

            builder.HasKey(ft => ft.ID);
            builder.Property(ft => ft.ID).UseIdentityColumn();
            builder.Property(ft => ft.ID).IsRequired();

            builder.Property(ft => ft.Name).IsRequired();
            builder.Property(ft => ft.Name).HasMaxLength(25);

            builder.HasData(new FuelType
            {
                ID = 1,
                Name = "Benzin"
            }, new FuelType
            {
                ID = 2,
                Name = "Benzin & Lpg"
            }, new FuelType
            {
                ID = 3,
                Name = "Dizel"
            }, new FuelType
            {
                ID = 4,
                Name = "Hybrid"
            }, new FuelType
            {
                ID = 5,
                Name = "Elektrik"
            });
        }
    }
}
