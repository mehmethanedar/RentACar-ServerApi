using FluentValidation;
using RentACar.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Business.ValidationRules.FluentValidation
{
    public class VehicleValidatior : AbstractValidator<Vehicle>
    {
        public VehicleValidatior()
        {
            RuleFor(x => x.CaseTypeID).NotEmpty();
            RuleFor(x => x.ColorID).NotEmpty();
            RuleFor(x => x.CompanyID).NotEmpty();
            RuleFor(x => x.DailyCost).NotEmpty();
            RuleFor(x => x.DamageStatus).NotEmpty();
            RuleFor(x => x.DamageStatus).MaximumLength(50);
            RuleFor(x => x.Explanation).NotEmpty();
            RuleFor(x => x.Explanation).MaximumLength(200);
            RuleFor(x => x.FuelTypeID).NotEmpty();
            RuleFor(x => x.GearTypeID).NotEmpty();
            RuleFor(x => x.IsExists).NotEmpty();
            RuleFor(x => x.Kilometer).NotEmpty();
            RuleFor(x => x.VehicleModelID).NotEmpty();
            RuleFor(x => x.ViewsCount).NotEmpty();
        }
    }
}
