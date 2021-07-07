using RentACar.Core.DataAccess.EntityFramework;
using RentACar.Core.Entities.Concrete;
using RentACar.DataAccess.Abstract;
using RentACar.DataAccess.Concrete.EntityFramework.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.DataAccess.Concrete
{
    public class EfUserInformationDal : EfEntityRepositoryBase<UserInformation, RentACarDbContext>, IUserInformationDal
    {
        public List<OperationClaim> GetClaims(UserInformation userInformation)
        {
            using (var context = new RentACarDbContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                                 on operationClaim.ID equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == userInformation.ID
                             select new OperationClaim { ID = operationClaim.ID, Name = operationClaim.Name };
                return result.ToList();

            }
        }
    }
}
