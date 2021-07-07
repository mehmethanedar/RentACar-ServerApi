using RentACar.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Entities.Dtos.Get
{
    public class CityGetDto : IDto
    {
        public string Name { get; set; }
        public int CountryID { get; set; }
    }
}
