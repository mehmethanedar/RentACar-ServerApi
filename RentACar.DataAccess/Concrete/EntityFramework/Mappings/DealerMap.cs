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
    public class DealerMap : IEntityTypeConfiguration<Dealer>
    {
        public void Configure(EntityTypeBuilder<Dealer> builder)
        {
            builder.ToTable("Dealers");

            builder.HasKey(d => d.ID);
            builder.Property(d => d.ID).IsRequired();
            builder.Property(d => d.ID).UseIdentityColumn();

            builder.Property(d => d.Name).IsRequired();
            builder.Property(d => d.Name).HasMaxLength(50);

            builder.Property(d => d.OpeningDate).IsRequired();
            builder.Property(d => d.AddressID).IsRequired();
            builder.Property(d => d.CompanyID).IsRequired();

            builder.HasOne(d => d.Address).WithMany(t => t.Dealers).HasForeignKey(d => d.AddressID);
            builder.HasOne(d => d.Company).WithMany(t => t.Dealers).HasForeignKey(d => d.CompanyID);



            builder.HasData(new Dealer
            {
                ID = 1,
                Name = "name ne işe yaıyor burda hatırlamıyorum",
                AddressID=1,
                CompanyID=1,
                OpeningDate=DateTime.Now
            }, new Dealer
            {
                ID = 2,
                Name = "name ne işe yaıyor burda hatırlamıyorum",
                AddressID = 2,
                CompanyID = 2,
                OpeningDate = DateTime.Now
            });
        }
    }
}
