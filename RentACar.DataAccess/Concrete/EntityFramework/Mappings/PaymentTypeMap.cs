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
    public class PaymentTypeMap : IEntityTypeConfiguration<PaymentType>
    {
        public void Configure(EntityTypeBuilder<PaymentType> builder)
        {
            builder.ToTable("PaymentTypes");

            builder.HasKey(ct => ct.ID);
            builder.Property(ct => ct.ID).UseIdentityColumn();
            builder.Property(ct => ct.ID).IsRequired();

            builder.Property(ct => ct.Name).IsRequired();
            builder.Property(ct => ct.Name).HasMaxLength(50);


            builder.HasData(new PaymentType
            {
                ID = 1,
                Name = "Nakit"

            }, new PaymentType
            {
                ID = 2,
                Name = "Kredi Kartı"
            });

        }
    }
}
