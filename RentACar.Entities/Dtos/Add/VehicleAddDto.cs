using RentACar.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Entities.Dtos.Add
{
    public class VehicleAddDto : IDto
    {
        public int FuelTypeID { get; set; }
        public int GearTypeID { get; set; }
        public int VehicleModelID { get; set; }
        public int ColorID { get; set; }
        public int CompanyID { get; set; }
        public int CaseTypeID { get; set; }
        public string DamageStatus { get; set; }
        public string Explanation { get; set; }
        public int Kilometer { get; set; }
        public bool IsExists { get; set; }
        public int DailyCost { get; set; }
        public int ViewsCount { get; set; }
        public int seats { get; set; }
        public string speed { get; set; }
        public List<string> Pictures { get; set; }
    }
}
