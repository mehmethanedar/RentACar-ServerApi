using RentACar.Core.Entities;
using System.Collections.Generic;

namespace RentACar.Entities.Concrete
{
    public class District : IEntity
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int TownID { get; set; }
        public virtual Town Town { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
    }
}
