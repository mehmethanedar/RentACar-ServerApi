using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Core.Entities.Concrete
{
    public class UserInformation : IEntity
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Discriminator { get; set; } = "Employee";
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        public bool Status { get; set; } = false;
        public string ActivationCode { get; set; }
        public virtual ICollection<UserOperationClaim> UserOperationClaims { get; set; }
    }
}
