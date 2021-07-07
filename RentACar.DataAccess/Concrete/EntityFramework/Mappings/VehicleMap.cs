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
    public class VehicleMap : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.ToTable("Vehicles");

            builder.HasKey(ct => ct.ID);
            builder.Property(ct => ct.ID).UseIdentityColumn();
            builder.Property(ct => ct.ID).IsRequired();

            builder.Property(ct => ct.DamageStatus).IsRequired();
            builder.Property(ct => ct.DamageStatus).HasMaxLength(50);

            builder.Property(ct => ct.Explanation).IsRequired();
            builder.Property(ct => ct.Explanation).HasMaxLength(200);

            // Entry girilirken tarihi de ekler
            //builder.Property(ct => ct.CreationDate).HasDefaultValue(DateTime.Now);

            builder.Property(ct => ct.IsExists).IsRequired();
            builder.Property(ct => ct.IsExists).HasDefaultValue(true);

            builder.Property(ct => ct.DailyCost).IsRequired();

            builder.Property(ct => ct.ViewsCount).IsRequired();
            builder.Property(ct => ct.ViewsCount).HasDefaultValue(0);


            builder.HasOne(d => d.FuelType).WithMany(t => t.Vehicles).HasForeignKey(d => d.FuelTypeID);
            builder.HasOne(d => d.GearType).WithMany(t => t.Vehicles).HasForeignKey(d => d.GearTypeID);
            builder.HasOne(d => d.VehicleModel).WithMany(t => t.Vehicles).HasForeignKey(d => d.VehicleModelID);
            builder.HasOne(d => d.Color).WithMany(t => t.Vehicles).HasForeignKey(d => d.ColorID);
            builder.HasOne(d => d.Company).WithMany(t => t.Vehicles).HasForeignKey(d => d.CompanyID);
            builder.HasOne(d => d.CaseType).WithMany(t => t.Vehicles).HasForeignKey(d => d.CaseTypeID);

            builder.HasData(new Vehicle
            {
                ID = 1,
                FuelTypeID = 1,
                GearTypeID = 1,
                VehicleModelID = 1,
                ColorID = 1,
                CompanyID = 1,
                DamageStatus = "Hasar yok",
                Explanation = "İlk araç açıklaması",
                DailyCost = 100,
                CaseTypeID=1,
                CreationDate=DateTime.Now,
                Kilometer=15478,
                IsExists=true,
                ViewsCount=1
            }, new Vehicle
            {
                ID = 2,
                FuelTypeID = 1,
                GearTypeID = 1,
                VehicleModelID = 1,
                ColorID = 1,
                CompanyID = 1,
                DamageStatus = "Hasar yok",
                Explanation = "İkinci araç açıklaması",
                DailyCost = 200,
                CaseTypeID = 1,
                CreationDate = DateTime.Now,
                Kilometer = 20000,
                IsExists = true,
                ViewsCount = 1
            });

        }
    }
}
