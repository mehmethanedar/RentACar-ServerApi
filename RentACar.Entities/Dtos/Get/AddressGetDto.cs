using RentACar.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Entities.Dtos.Get
{
    public class AddressGetDto : IDto
    {
        public string PostalCode { get; set; }
        public string FullAddress { get; set; }
        public DateTime CreationDate { get; set; }
        public bool Status { get; set; }
        public int DistrictID { get; set; }
        public int CountryID { get; set; }
        public int CityId { get; set; }
        public int TownId { get; set; }
    }
}
