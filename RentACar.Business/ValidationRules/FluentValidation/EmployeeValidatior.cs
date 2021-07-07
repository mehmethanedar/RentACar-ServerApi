using FluentValidation;
using RentACar.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Business.ValidationRules.FluentValidation
{
    public class EmployeeValidatior : AbstractValidator<Employee>
    {
        public EmployeeValidatior()
        {
            RuleFor(x => x.AddressID).NotEmpty();
            RuleFor(x => x.BirthDate).NotEmpty();

            RuleFor(x => x.CitizenId).NotEmpty();
            RuleFor(x => x.CitizenId).Length(11);

            RuleFor(x => x.DealerID).NotEmpty();
            //RuleFor(x => x.Email).NotEmpty();
            //RuleFor(x => x.Email).Length(50);

            RuleFor(x => x.Gender).NotEmpty();

            //RuleFor(x => x.Name).NotEmpty();
            //RuleFor(x => x.Name).MaximumLength(50);

            //RuleFor(x => x.Password).NotEmpty();
            //RuleFor(x => x.Password).MaximumLength(20);

            RuleFor(x => x.Phone_1).NotEmpty();
            RuleFor(x => x.Phone_1).MaximumLength(20);

            RuleFor(x => x.Phone_2).MaximumLength(20);

            RuleFor(x => x.Salary).NotEmpty();

            //RuleFor(x => x.Surname).NotEmpty();
            //RuleFor(x => x.Surname).MaximumLength(50);

            RuleFor(x => x.Username).NotEmpty();
            RuleFor(x => x.Username).MaximumLength(20);

            //RuleFor(x => x.Name).NotEmpty();
            //RuleFor(x => x.Name).MaximumLength(50);
        }
    }
}
