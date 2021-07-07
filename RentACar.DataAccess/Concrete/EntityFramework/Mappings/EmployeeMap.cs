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
    public class EmployeeMap : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employees");

            //builder.HasKey(e => e.ID);
            //builder.Property(e => e.ID).UseIdentityColumn();
            //builder.Property(e => e.ID).IsRequired();

            //builder.Property(e => e.Name).IsRequired();
            //builder.Property(e => e.Name).HasMaxLength(50);

            builder.Property(e => e.Username).IsRequired();
            builder.Property(e => e.Username).HasMaxLength(20);

            //builder.Property(e => e.Password).IsRequired();
            //builder.Property(e => e.Password).HasMaxLength(20);



            //builder.Property(c => c.PasswordSalt).IsRequired();
            //builder.Property(c => c.PasswordSalt).HasMaxLength(250);
            //builder.Property(c => c.PasswordHash).IsRequired();
            //builder.Property(c => c.PasswordHash).HasMaxLength(250);


            builder.Property(e => e.BirthDate).HasColumnType("Password");

            //builder.Property(e => e.Surname).IsRequired();
            //builder.Property(e => e.Surname).HasMaxLength(50);

            //builder.Property(e => e.Email).IsRequired();
            //builder.Property(e => e.Email).HasMaxLength(50);
            builder.Property(e => e.BirthDate).HasColumnType("EmailAddress");

            builder.Property(e => e.Status).IsRequired();

            builder.Property(e => e.Salary).IsRequired();

            builder.Property(e => e.DealerID).IsRequired();

            builder.Property(e => e.CitizenId).IsRequired();
            builder.Property(e => e.CitizenId).HasMaxLength(11);

            builder.Property(e => e.Gender).IsRequired();

            builder.Property(e => e.BirthDate).IsRequired();
            builder.Property(e => e.BirthDate).HasColumnType("date");

            builder.Property(e => e.CreationDate).IsRequired();
            builder.Property(e => e.CreationDate).HasColumnType("timestamp without time zone");

            builder.Property(e => e.ModificationDate).HasColumnType("timestamp without time zone");

            builder.Property(e => e.Phone_1).IsRequired();
            builder.Property(e => e.Phone_1).HasMaxLength(20);

            builder.Property(e => e.Phone_2).HasMaxLength(20);

            builder.Property(e => e.AddressID).IsRequired();

            builder.HasOne(d => d.Dealer).WithMany(t => t.Employees).HasForeignKey(d => d.DealerID);
            builder.HasOne(d => d.Address).WithMany(t => t.Employees).HasForeignKey(d => d.AddressID);

            builder.HasData(new Employee
            {
                ID = 1,
                //Name = "Hüseyin",
                FirstName = "AHMET",
                Username = "HANEDAR",
                //Password = "Mh1453,.123A",
                //Surname = "HANEDAR",
                //Email = "mehmethanedar@hotmail.com",
                LastName = "HANEDAR",
                Email = "ahmethanedar@hotmail.com",
                PasswordSalt = new byte[] { 1, 2, 3, 4, 5 },
                PasswordHash = new byte[] { 1, 2, 3, 4, 5 },
                CitizenId = "12457821547",
                Gender = 0,
                BirthDate = new DateTime(1985,2,2),
                CreationDate = DateTime.Now,
                ModificationDate = DateTime.Now,
                Phone_1 = "05368521453",
                Phone_2 = null,
                AddressID = 1,
                DealerID = 1,
                Status = false,
                Salary = 5000,
                ActivationCode="asdfasd"

            }, new Employee
            {
                ID = 2,
                //Name = "cemre",
                FirstName = "ömer",
                Username = "çolak",
                //Password = "sdgfA,.123A",
                //Surname = "çolak",
                //Email = "mehmethanedar@hotmail.com",
                LastName = "çolak",
                PasswordSalt = new byte[] { 1, 2, 3, 4, 5 },
                PasswordHash = new byte[] { 1, 2, 3, 4, 5 },
                Email = "mehmethanedar@hotmail.com",
                CitizenId = "12457821547",
                Gender = 0,
                BirthDate = new DateTime(1985,2,2),
                CreationDate = DateTime.Now,
                ModificationDate = DateTime.Now,
                Phone_1 = "0258472529",
                Phone_2 = null,
                AddressID = 1,
                DealerID = 1,
                Status = false,
                Salary = 5000,
                ActivationCode = "asdsssfasd"
            });;
        }
    }
}
