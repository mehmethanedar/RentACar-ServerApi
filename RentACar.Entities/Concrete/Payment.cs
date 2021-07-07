using RentACar.Core.Entities;
using System;

namespace RentACar.Entities.Concrete
{
    public class Payment : IEntity
    {
        public int ID { get; set; }
        public DateTime PaymentDate { get; set; } = DateTime.Now;
        public string ApproveCode { get; set; }
        public bool IsOk { get; set; }
        public float TotalPayment { get; set; }
        public int PaymentTypeID { get; set; }
        public int OrderID { get; set; }
        public virtual PaymentType PaymentType { get; set; }
        public virtual Order Order { get; set; }
    }
}
