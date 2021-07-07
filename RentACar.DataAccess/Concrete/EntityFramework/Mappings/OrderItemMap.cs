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
    public class OrderItemMap : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.ToTable("OrderItem");

            builder.HasKey(ct => ct.ID);
            builder.Property(ct => ct.ID).UseIdentityColumn();
            builder.Property(ct => ct.ID).IsRequired();

            builder.Property(ct => ct.Quantity).IsRequired();
            builder.Property(ct => ct.Cost).IsRequired();
            builder.Property(ct => ct.OrderID).IsRequired();
            builder.Property(ct => ct.VehicleID).IsRequired();

            builder.HasOne(d => d.Order).WithMany(t => t.OrderItems).HasForeignKey(d => d.OrderID);
            builder.HasOne(d => d.Vehicle).WithMany(t => t.OrderItems).HasForeignKey(d => d.VehicleID);

            builder.HasData(new OrderItem
            {
                ID = 1,
                Quantity = 50,
                Cost = 27.5,
                OrderID = 1,
                VehicleID = 1

            }, new OrderItem
            {
                ID = 2,
                Quantity = 550,
                Cost = 275.5,
                OrderID = 1,
                VehicleID = 1
            });
        }
    }
}
