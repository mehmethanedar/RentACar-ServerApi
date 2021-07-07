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
    public class InvoiceMap : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.ToTable("Invoices");

            builder.HasKey(x => x.ID);
            builder.Property(x => x.ID).UseIdentityColumn();
            builder.Property(x => x.ID).IsRequired();

            builder.Property(x => x.InvoiceDate).IsRequired();

            builder.Property(x => x.CreationDate).IsRequired();

            builder.Property(x => x.TotalPrice).IsRequired();

            builder.Property(x => x.EmployeeID).IsRequired();

            builder.Property(x => x.OrderID).IsRequired();

            builder.HasOne(d => d.Employee).WithMany(t => t.Invoices).HasForeignKey(d => d.EmployeeID);
            builder.HasOne(d => d.Order).WithMany(t => t.Invoices).HasForeignKey(d => d.OrderID);
            builder.HasData(new Invoice
            {
                ID = 1,
                InvoiceDate = DateTime.Now,
                CreationDate = DateTime.Now,
                TotalPrice = 3999,
                EmployeeID = 1,
                OrderID = 1,
            }, new Invoice
            {
                ID = 2,
                InvoiceDate = DateTime.Now,
                CreationDate = DateTime.Now,
                TotalPrice = 159,
                EmployeeID = 1,
                OrderID = 1,
            });
        }
    }
}
