using RentACar.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RentACar.Entities.Concrete
{
    public class Town : IEntity
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int CityID { get; set; }
        public virtual City City { get; set; }
        public virtual ICollection<District> Districts { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
    }
}
