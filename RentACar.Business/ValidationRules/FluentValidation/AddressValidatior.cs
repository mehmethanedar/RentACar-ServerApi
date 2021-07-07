using FluentValidation;
using RentACar.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Business.ValidationRules.FluentValidation
{
    public class AddressValidatior : AbstractValidator<Address>
    {
        public AddressValidatior()
        {
            RuleFor(x => x.DistrictID).NotEmpty();
            RuleFor(x => x.Status).NotEmpty();
            RuleFor(x => x.FullAddress).NotEmpty();
            RuleFor(x => x.FullAddress).Length(5, 250);
            RuleFor(x => x.FullAddress).MaximumLength(250);
        }
    }
}
