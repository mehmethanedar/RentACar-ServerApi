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
    public class CompanyMap : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.ToTable("Companies");

            builder.HasKey(c => c.ID);
            builder.Property(c => c.ID).UseIdentityColumn();
            builder.Property(c => c.ID).IsRequired();

            builder.Property(c => c.Brand).IsRequired();
            builder.Property(c => c.Brand).HasMaxLength(50);

            builder.Property(c => c.FoundationDate).IsRequired();

            builder.Property(c => c.TaxNumber).IsRequired();
            builder.Property(c => c.TaxNumber).HasMaxLength(50);

            builder.Property(c => c.About).IsRequired();
            builder.Property(c => c.LogoUrl).IsRequired();

            builder.Property(c => c.Status).IsRequired();


            builder.Property(c => c.Phone_1).IsRequired();
            builder.Property(c => c.Phone_1).HasMaxLength(20);

            builder.Property(c => c.Phone_2).HasMaxLength(20);

            builder.Property(c => c.AddressID).IsRequired();

            builder.Property(c => c.CreationDate).IsRequired();


            builder.Property(c => c.CitizenId).IsRequired();
            builder.Property(c => c.CitizenId).HasMaxLength(11);

            builder.Property(c => c.Gender).IsRequired();

            builder.Property(c => c.BirthDate).IsRequired();

            //builder.Property(c => c.Name).IsRequired();
            //builder.Property(c => c.Name).HasMaxLength(50);

            //builder.Property(c => c.Username).IsRequired();
            //builder.Property(c => c.Username).HasMaxLength(20);

            //builder.Property(c => c.Password).IsRequired();
            //builder.Property(c => c.Password).HasMaxLength(20);


            //builder.Property(c => c.PasswordSalt).IsRequired();
            //builder.Property(c => c.PasswordSalt).HasMaxLength(250);
            //builder.Property(c => c.PasswordHash).IsRequired();
            //builder.Property(c => c.PasswordHash).HasMaxLength(250);


            //builder.Property(c => c.Surname).IsRequired();
            //builder.Property(c => c.Surname).HasMaxLength(50);

            //builder.Property(c => c.Email).IsRequired();
            //builder.Property(c => c.Email).HasMaxLength(50);


            //builder.HasOne(d => d.Owner).WithMany(t => t.Companies).HasForeignKey(d => d.OwnerID);
            //builder.HasOne(d => d.Address).WithMany(t => t.Companies).HasForeignKey(d => d.AddressID);



            builder.HasData(new Company
            {
                ID = 1,
                About = "Firmamız kuruluş amacı test içindir. burası deneme yazısı",
                Brand="HANEDAR",
                CreationDate=DateTime.Now,
                FoundationDate=DateTime.Now,
                LogoUrl="www.hanedar.com/url",
                Status=true,
                TaxNumber="2548965416516",
                //Name = "Hüseyin",
                //Username = "HANEDAR",
                //Password = "Mh1453,.123A",
                //Surname = "HANEDAR",
                //Email = "mehmethanedar@hotmail.com",
                CitizenId = "12457821547",
                Gender = 0,
                BirthDate = new DateTime(1985, 2, 2),
                ModificationDate = DateTime.Now,
                Phone_1 = "05368521453",
                Phone_2 = null,
                AddressID = 1,

            }, new Company
            {
                ID = 2,
                About = "Firmamız kuruluş amacı test içindir. burası deneme yazısı",
                Brand = "YAZILIM",
                CreationDate = DateTime.Now,
                FoundationDate = DateTime.Now,
                LogoUrl = "www.hanedarYAZILIM.com/url",
                Status = true,
                TaxNumber = "2548965416516",
                //Name = "Hüseyin",
                //Username = "HANEDAR",
                //Password = "Mh1453,.123A",
                //Surname = "HANEDAR",
                //Email = "mehmethanedar@hotmail.com",
                CitizenId = "12457821547",
                Gender = 0,
                BirthDate = new DateTime(1985, 2, 2),
                ModificationDate = DateTime.Now,
                Phone_1 = "05368521453",
                Phone_2 = null,
                AddressID = 1

            });
        }
    }
}
