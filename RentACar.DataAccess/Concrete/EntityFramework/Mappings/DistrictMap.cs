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
    public class DistrictMap : IEntityTypeConfiguration<District>
    {
        public void Configure(EntityTypeBuilder<District> builder)
        {
            builder.ToTable("Districts");

            builder.HasKey(d => d.ID);
            builder.Property(d => d.ID).UseIdentityColumn();
            builder.Property(d => d.ID).IsRequired();

            builder.Property(d => d.Name).IsRequired();
            builder.Property(d => d.Name).HasMaxLength(100);

            builder.HasOne(d => d.Town).WithMany(t => t.Districts).HasForeignKey(d => d.TownID);

            builder.HasData(new District
            {
                ID = 1,
                Name = "Çapa",
                TownID = 1
            }, new District
            {
                ID = 2,
                Name = "Fındıkzade",
                TownID = 1
            });
        }
    }
}
