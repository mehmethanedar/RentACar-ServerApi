using RentACar.Core.Entities;
using System.Collections.Generic;

namespace RentACar.Entities.Concrete
{
    public class Color : IEntity
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}
