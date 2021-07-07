using RentACar.Core.Entities.Concrete;
using RentACar.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RentACar.Entities.Abstract
{
    public enum Gender
    {
        Male = 0,//erkek
        Female = 1//kız
    }
    public abstract class User
    {
        public int ID { get; set; }
        public string CitizenId { get; set; }
        public Gender Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public DateTime ModificationDate { get; set; } = DateTime.Now;
        public string Phone_1 { get; set; }
        public string Phone_2 { get; set; }
        public int AddressID { get; set; }
        public virtual Address Address { get; set; }
    }
}
