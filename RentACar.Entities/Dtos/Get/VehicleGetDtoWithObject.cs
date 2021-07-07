using RentACar.Core.Entities;
using RentACar.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Entities.Dtos.Get
{
    public class VehicleGetDtoWithObject:IDto
    {
        public int ID { get; set; }
        public int CompanyID { get; set; }
        public string DamageStatus { get; set; }
        public string Explanation { get; set; }
        public int Kilometer { get; set; }
        public DateTime CreationDate { get; set; }
        public bool IsExists { get; set; }
        public int DailyCost { get; set; }
        public int ViewsCount { get; set; }
        public List<string> Pictures { get; set; }
        public FuelTypeGetDto FuelType { get; set; }
        public GearTypeGetDto GearType { get; set; }
        public VehicleModelGetDto VehicleModel { get; set; }
        public CaseTypeGetDto CaseType { get; set; }
        public ColorGetDto Color { get; set; }
    }
}
