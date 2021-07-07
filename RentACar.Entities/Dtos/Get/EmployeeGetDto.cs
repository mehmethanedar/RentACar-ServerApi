using RentACar.Core.Entities;
using RentACar.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Entities.Dtos.Get
{
    public class EmployeeGetDto : IDto
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Salary { get; set; }
        public int DealerID { get; set; }
        public string Username { get; set; }
        public string CitizenId { get; set; }
        public Gender Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModificationDate { get; set; }
        public string Phone_1 { get; set; }
        public string Phone_2 { get; set; }
        public int AddressID { get; set; }
    }
}
