using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Core.Entities.Concrete
{
    public class OperationClaim
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public virtual ICollection<UserOperationClaim> UserOperationClaims { get; set; }
    }
}
