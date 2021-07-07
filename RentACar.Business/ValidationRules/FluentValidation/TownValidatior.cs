using FluentValidation;
using RentACar.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Business.ValidationRules.FluentValidation
{
    public class TownValidatior : AbstractValidator<Town>
    {
        public TownValidatior()
        {
            RuleFor(x => x.CityID).NotEmpty();

            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Name).MaximumLength(50);
        }
    }
}
