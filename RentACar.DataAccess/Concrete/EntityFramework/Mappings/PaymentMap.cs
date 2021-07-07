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
    public class PaymentMap : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.ToTable("Payments");

            builder.HasKey(ct => ct.ID);
            builder.Property(ct => ct.ID).UseIdentityColumn();
            builder.Property(ct => ct.ID).IsRequired();

            //builder.Property(ct => ct.PaymentDate).HasDefaultValue(DateTime.Now);

            builder.Property(ct => ct.ApproveCode).IsRequired();
            builder.Property(ct => ct.ApproveCode).HasMaxLength(50);

            builder.Property(ct => ct.IsOk).IsRequired();

            builder.Property(ct => ct.TotalPayment).IsRequired();

            builder.HasOne(d => d.PaymentType).WithMany(t => t.Payments).HasForeignKey(d => d.PaymentTypeID);
            builder.HasOne(d => d.Order).WithMany(t => t.Payments).HasForeignKey(d => d.OrderID);

            builder.HasData(new Payment
            {
                ID = 1,
                ApproveCode = "A",
                IsOk = true,
                TotalPayment = 300.0f,
                PaymentTypeID = 1,
                PaymentDate=DateTime.Now,
                OrderID=1

            }, new Payment
            {
                ID = 2,
                ApproveCode = "B",
                IsOk = true,
                TotalPayment = 300.0f,
                PaymentTypeID = 1,
                PaymentDate = DateTime.Now,
                OrderID = 1
            });

        }
    }
}
