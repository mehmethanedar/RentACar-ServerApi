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
    public class OrderMap : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");

            builder.HasKey(x => x.ID);
            builder.Property(x => x.ID).UseIdentityColumn();
            builder.Property(x => x.ID).IsRequired();

            builder.Property(x => x.TotalAmount).IsRequired();
            builder.Property(x => x.OrderDate).IsRequired();
            builder.Property(x => x.Status).IsRequired();
            builder.Property(x => x.CustomerID).IsRequired();
            builder.Property(x => x.DealerID).IsRequired();
            builder.Property(x => x.VehicleID).IsRequired();

            builder.HasOne(d => d.Customer).WithMany(t => t.Orders).HasForeignKey(d => d.CustomerID);
            builder.HasOne(d => d.Dealer).WithMany(t => t.Orders).HasForeignKey(d => d.DealerID);
            builder.HasOne(d => d.Vehicle).WithMany(t => t.Orders).HasForeignKey(d => d.VehicleID);
            builder.HasData(new Order
            {
                ID = 1,
                TotalAmount = 155.5,
                OrderDate = DateTime.Now,
                Status = true,
                CustomerID = 1,
                DealerID = 1,
                VehicleID = 1

            }, new Order
            {
                ID = 2,
                TotalAmount = 1947.5,
                OrderDate = DateTime.Now,
                Status = true,
                CustomerID = 1,
                DealerID = 1,
                VehicleID = 1
            });
        }
    }
}
