﻿using RentACar.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Entities.Dtos.Add
{
    public class DistrictAddDto : IDto
    {
        public string Name { get; set; }
        public int TownID { get; set; }
    }
}
