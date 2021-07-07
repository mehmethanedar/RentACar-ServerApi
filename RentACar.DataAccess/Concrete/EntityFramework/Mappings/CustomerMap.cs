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
    public class CustomerMap : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers");

            builder.HasKey(c => c.ID);
            builder.Property(c => c.ID).UseIdentityColumn();
            builder.Property(c => c.ID).IsRequired();

            //builder.Property(c => c.Name).IsRequired();
            //builder.Property(c => c.Name).HasMaxLength(50);

            //builder.Property(c => c.Username).IsRequired();
            //builder.Property(c => c.Username).HasMaxLength(20);

            //builder.Property(c => c.Password).IsRequired();
            //builder.Property(c => c.Password).HasMaxLength(250);


            //builder.Property(c => c.PasswordSalt).IsRequired();
            //builder.Property(c => c.PasswordSalt).HasMaxLength(250);
            //builder.Property(c => c.PasswordHash).IsRequired();
            //builder.Property(c => c.PasswordHash).HasMaxLength(250);


            //builder.Property(c => c.Surname).IsRequired();
            //builder.Property(c => c.Surname).HasMaxLength(50);

            //builder.Property(c => c.Email).IsRequired();
            //builder.Property(c => c.Email).HasMaxLength(50);

            builder.Property(c => c.Status).IsRequired();

            builder.Property(c => c.CitizenId).IsRequired();
            builder.Property(c => c.CitizenId).HasMaxLength(11);

            builder.Property(c => c.BirthDate).IsRequired();
            //builder.Property(c => c.BirthDate).HasColumnType("Date");

            builder.Property(c => c.CreationDate).IsRequired();
            //builder.Property(c => c.CreationDate).HasColumnType("DateTime");

            //builder.Property(c => c.ModificationDate).HasColumnType("DateTime");

            builder.Property(c => c.Phone_1).IsRequired();
            builder.Property(c => c.Phone_1).HasMaxLength(20);

            builder.Property(c => c.Status).IsRequired();

            builder.HasOne(d => d.DriverLicence).WithMany(t => t.Customers).HasForeignKey(d => d.DriverLicenceID);



            builder.HasData(new Customer
            {
                ID = 1,
                //FirstName = "AHMET",
                //Username = "HANEDAR",
                //Password = "Mh1453,.123A",
                //LastName = "HANEDAR",
                //Email = "ahmethanedar@hotmail.com",
                //PasswordSalt = new byte[] { 1, 2, 3, 4, 5 },
                //PasswordHash = new byte[] { 1, 2, 3, 4, 5 },
                CitizenId = "12457821547",
                Phone_1 = "05368521453",
                Status = true,
                BirthDate= new DateTime(1992,5,2),
                CreationDate = DateTime.Now,
                DriverLicenceID=1,
                ModificationDate= DateTime.Now,


            }, new Customer
            {
                ID = 2,
                //FirstName = "ömer",
                //Username = "çolak",
                //Password = "sdgfA,.123A",
                //LastName = "çolak",
                //PasswordSalt = new byte[] {1,2,3,4,5},
                //PasswordHash = new byte[] {1,2,3,4,5},
                //Email = "mehmethanedar@hotmail.com",
                CitizenId = "12457821547",
                Phone_1 = "0258472529",
                Status = true,
                BirthDate = new DateTime(1950,5,14),
                CreationDate = DateTime.Now,
                DriverLicenceID = 1,
                ModificationDate = DateTime.Now,
            });
        }
    }
}
