using FluentValidation;
using RentACar.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Business.ValidationRules.FluentValidation
{
    public class PaymentValidatior : AbstractValidator<Payment>
    {
        public PaymentValidatior()
        {
            RuleFor(x => x.ApproveCode).NotEmpty();
            RuleFor(x => x.ApproveCode).MaximumLength(50);

            RuleFor(x => x.IsOk).NotEmpty();
            RuleFor(x => x.PaymentTypeID).NotEmpty();
            RuleFor(x => x.PaymentDate).NotEmpty();
            RuleFor(x => x.TotalPayment).NotEmpty();
        }
    }
}
