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
    public class VehicleCategoryMap : IEntityTypeConfiguration<VehicleCategory>
    {
        public void Configure(EntityTypeBuilder<VehicleCategory> builder)
        {
            builder.ToTable("VehicleCategories");

            builder.HasKey(ct => ct.ID);
            builder.Property(ct => ct.ID).UseIdentityColumn();
            builder.Property(ct => ct.ID).IsRequired();

            builder.Property(ct => ct.Name).IsRequired();
            builder.Property(ct => ct.Name).HasMaxLength(50);


            builder.HasData(new VehicleCategory
            {
                ID = 1,
                Name = "Otomobil"
            }, new VehicleCategory
            {
                ID = 2,
                Name = "Kamyonet"
            });

        }
    }
}
