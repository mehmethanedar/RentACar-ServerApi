using RentACar.Core.Entities;
using System.Collections.Generic;

namespace RentACar.Entities.Concrete
{
    public class City : IEntity
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int CountryID { get; set; }
        public virtual Country Country { get; set; }
        public virtual ICollection<Town> Towns { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
    }
}
