using RentACar.Core.Entities;
using RentACar.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Entities.Dtos.Get
{
    public class VehicleBrandGetDto : IDto
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public VehicleCategoryGetDto VehicleCategory { get; set; }
    }
}
