using FluentValidation;
using RentACar.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Business.ValidationRules.FluentValidation
{
    public class DistrictValidatior : AbstractValidator<District>
    {
        public DistrictValidatior()
        {
            RuleFor(x => x.TownID).NotEmpty();

            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Name).MaximumLength(100);
            RuleFor(x => x.Name).Length(3, 100);
        }
    }
}