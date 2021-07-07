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
    public class VehicleModelMap : IEntityTypeConfiguration<VehicleModel>
    {
        public void Configure(EntityTypeBuilder<VehicleModel> builder)
        {
            builder.ToTable("VehicleModels");

            builder.HasKey(ct => ct.ID);
            builder.Property(ct => ct.ID).UseIdentityColumn();
            builder.Property(ct => ct.ID).IsRequired();

            builder.Property(ct => ct.Name).IsRequired();
            builder.Property(ct => ct.Name).HasMaxLength(50);

            builder.HasOne(ct => ct.VehicleBrand).WithMany(ct => ct.VehicleModels).HasForeignKey(ct=>ct.VehicleBrandID);
            builder.HasData(new VehicleModel
            {
                ID = 1,
                Name = "A Serisi",
                VehicleBrandID = 1

            }, new VehicleModel
            {
                ID = 2,
                Name = "B Serisi",
                VehicleBrandID = 1
            });

        }
    }
}
