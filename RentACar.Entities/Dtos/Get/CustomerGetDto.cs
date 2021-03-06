using RentACar.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Entities.Dtos.Get
{
    public class CustomerGetDto : IDto
    {
        public int ID { get; set; }
        public string CitizenId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public string Phone_1 { get; set; }
        public int DriverLicenceID { get; set; }
    }
}
