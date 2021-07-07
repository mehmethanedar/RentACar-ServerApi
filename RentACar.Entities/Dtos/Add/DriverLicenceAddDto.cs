using RentACar.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Entities.Dtos.Add
{
    public class DriverLicenceAddDto : IDto
    {
        public string LicenceClass { get; set; }
    }
}
