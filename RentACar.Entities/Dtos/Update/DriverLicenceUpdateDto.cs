﻿using RentACar.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Entities.Dtos.Update
{
    public class DriverLicenceUpdateDto : IDto
    {
        public int ID { get; set; }
        public string LicenceClass { get; set; }
    }
}
