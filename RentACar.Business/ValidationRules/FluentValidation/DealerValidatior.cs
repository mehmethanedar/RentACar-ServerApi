using FluentValidation;
using RentACar.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Business.ValidationRules.FluentValidation
{
    public class DealerValidatior : AbstractValidator<Dealer>
    {
        public DealerValidatior()
        {
            RuleFor(x => x.AddressID).NotEmpty();
            RuleFor(x => x.CompanyID).NotEmpty();

            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Name).MaximumLength(50);
        }
    }
}
