using RentACar.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Entities.Dtos.Add
{
    public class DealerAddDto : IDto
    {
        public string Name { get; set; }
        public DateTime OpeningDate { get; set; }
        public int AddressID { get; set; }
        public int CompanyID { get; set; }
    }
}
