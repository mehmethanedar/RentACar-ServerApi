using FluentValidation;
using RentACar.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Business.ValidationRules.FluentValidation
{
    public class DriverLicenceValidatior : AbstractValidator<DriverLicence>
    {
        public DriverLicenceValidatior()
        {
            RuleFor(x => x.LicenceClass).NotEmpty();
            RuleFor(x => x.LicenceClass).MaximumLength(10);
        }
    }
}
