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
    public class UserOperationClaimMap : IEntityTypeConfiguration<UserOperationClaim>
    {
        public void Configure(EntityTypeBuilder<UserOperationClaim> builder)
        {
            builder.ToTable("UserOperationClaims");

            builder.HasKey(cr => new { cr.UserId, cr.OperationClaimId });

            builder.HasOne(cr => cr.User).WithMany(u => u.UserOperationClaims).HasForeignKey(cr => cr.UserId);
            builder.HasOne(cr => cr.OperationClaim).WithMany(r => r.UserOperationClaims).HasForeignKey(cr => cr.OperationClaimId);


            //builder.HasData(new UserOperationClaim
            //{
            //    roleID = 1,
            //    userID = 1
            //});
        }
    }
}
