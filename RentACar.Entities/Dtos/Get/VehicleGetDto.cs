using RentACar.Core.Entities;
using RentACar.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Entities.Dtos.Get
{
    public class VehicleGetDto : IDto
    {
        public int ID { get; set; }
        public int FuelTypeID { get; set; }
        public int GearTypeID { get; set; }
        public int VehicleModelID { get; set; }
        public int ColorID { get; set; }
        public int CompanyID { get; set; }
        public int CaseTypeID { get; set; }
        public string DamageStatus { get; set; }
        public string Explanation { get; set; }
        public int Kilometer { get; set; }
        public DateTime CreationDate { get; set; }
        public bool IsExists { get; set; }
        public int DailyCost { get; set; }
        public int ViewsCount { get; set; }
        public int seats { get; set; }
        public string speed { get; set; }
        public List<string> Pictures { get; set; }
        public FuelType FuelType { get; set; }
        public GearType GearType { get; set; }
        public VehicleModel VehicleModel { get; set; }
        public CaseType CaseType { get; set; }
        public Color Color { get; set; }
    }
}
