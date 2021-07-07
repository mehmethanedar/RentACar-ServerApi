using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Core.Entities.Concrete
{
    public class UserOperationClaim : IEntity
    {
        public int UserId { get; set; }
        public int OperationClaimId { get; set; }
        public virtual UserInformation User { get; set; }
        public virtual OperationClaim OperationClaim { get; set; }
    }
}
