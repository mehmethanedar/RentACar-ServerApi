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
    public class VehicleBrandMap : IEntityTypeConfiguration<VehicleBrand>
    {
        public void Configure(EntityTypeBuilder<VehicleBrand> builder)
        {
            builder.ToTable("VehicleBrands");

            builder.HasKey(ct => ct.ID);
            builder.Property(ct => ct.ID).UseIdentityColumn();
            builder.Property(ct => ct.ID).IsRequired();

            builder.Property(ct => ct.Name).IsRequired();
            builder.Property(ct => ct.Name).HasMaxLength(50);

            builder.HasOne(ct => ct.VehicleCategory).WithMany(ct => ct.VehicleBrands).HasForeignKey(ct => ct.VehicleCategoryID);
            builder.HasData(new VehicleBrand
            {
                ID = 1,
                Name = "Mercedes",
                VehicleCategoryID = 1
            }, new VehicleBrand
            {
                ID = 2,
                Name = "BMW",
                VehicleCategoryID = 1
            });

        }
    }
}
