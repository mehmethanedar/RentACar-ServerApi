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
    public class GearTypeMap : IEntityTypeConfiguration<GearType>
    {
        public void Configure(EntityTypeBuilder<GearType> builder)
        {
            builder.ToTable("GearTypes");

            builder.HasKey(ct => ct.ID);
            builder.Property(ct => ct.ID).UseIdentityColumn();
            builder.Property(ct => ct.ID).IsRequired();

            builder.Property(ct => ct.Name).IsRequired();
            builder.Property(ct => ct.Name).HasMaxLength(25);

            builder.HasData(new GearType
            {
                ID = 1,
                Name = "Manuel"
            }, new GearType
            {
                ID = 2,
                Name = "Yarı Otomatik"
            }, new GearType
            {
                ID = 3,
                Name = "Otomatik"
            });
        }
    }
}
