using RentACar.Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Core.Utilities.Security.Jwt
{
    //Token üreticek
    public interface ITokenHelper
    {
       AccessToken CreateToken(UserInformation userInformation, List<OperationClaim> operationClaims);
    }
}