using RentACar.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Entities.Dtos.Update
{
    public class CaseTypeUpdateDto : IDto
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
