using RentACar.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Entities.Dtos.Add
{
    public class PaymentAddDto : IDto
    {
        public string ApproveCode { get; set; }
        public bool IsOk { get; set; }
        public float TotalPayment { get; set; }
        public int PaymentTypeID { get; set; }
        public int OrderID { get; set; }
    }
}
