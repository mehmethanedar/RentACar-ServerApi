using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentACar.Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.DataAccess.Concrete.EntityFramework.Mappings
{
    public class UserInformationMap : IEntityTypeConfiguration<UserInformation>
    {
        public void Configure(EntityTypeBuilder<UserInformation> builder)
        {
            builder.ToTable("Employees");

            builder.HasKey(c => c.ID);
            builder.Property(c => c.ID).UseIdentityColumn();
            builder.Property(c => c.ID).IsRequired();

            builder.Property(c => c.FirstName).IsRequired();
            builder.Property(c => c.LastName).IsRequired();
            builder.Property(c => c.Email).IsRequired();
            builder.Property(c => c.Status).IsRequired();

        }
    }
}
