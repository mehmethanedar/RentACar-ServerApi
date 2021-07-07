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
    public class DriverLicenceMap : IEntityTypeConfiguration<DriverLicence>
    {
        public void Configure(EntityTypeBuilder<DriverLicence> builder)
        {
            builder.ToTable("DriverLicences");

            builder.HasKey(dl => dl.ID);
            builder.Property(dl => dl.ID).UseIdentityColumn();
            builder.Property(dl => dl.ID).IsRequired();

            builder.Property(dl => dl.LicenceClass).IsRequired();
            builder.Property(dl => dl.LicenceClass).HasMaxLength(10);

            builder.HasData(new DriverLicence
            {
                ID = 1,
                LicenceClass = "M"
            }, new DriverLicence
            {
                ID = 2,
                LicenceClass = "A1"
            }, new DriverLicence
            {
                ID = 3,
                LicenceClass = "A2"
            }, new DriverLicence
            {
                ID = 4,
                LicenceClass = "A"
            }, new DriverLicence
            {
                ID = 5,
                LicenceClass = "B1"
            }, new DriverLicence
            {
                ID = 6,
                LicenceClass = "BE"
            }, new DriverLicence
            {
                ID = 7,
                LicenceClass = "C1"
            }, new DriverLicence
            {
                ID = 8,
                LicenceClass = "C1E"
            }, new DriverLicence
            {
                ID = 9,
                LicenceClass = "C"
            }, new DriverLicence
            {
                ID = 10,
                LicenceClass = "CE"
            }, new DriverLicence
            {
                ID = 11,
                LicenceClass = "D1"
            }, new DriverLicence
            {
                ID = 12,
                LicenceClass = "D1E"
            }, new DriverLicence
            {
                ID = 13,
                LicenceClass = "D"
            }, new DriverLicence
            {
                ID = 14,
                LicenceClass = "DE"
            }, new DriverLicence
            {
                ID = 15,
                LicenceClass = "F"
            }, new DriverLicence
            {
                ID = 16,
                LicenceClass = "G"
            });
        }
    }
}
