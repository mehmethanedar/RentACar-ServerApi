using FluentValidation;
using RentACar.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Business.ValidationRules.FluentValidation
{
    public class InvoiceValidatior : AbstractValidator<Invoice>
    {
        public InvoiceValidatior()
        {
            RuleFor(x => x.EmployeeID).NotEmpty();
            RuleFor(x => x.OrderID).NotEmpty();
            RuleFor(x => x.TotalPrice).NotEmpty();
        }
    }
}
