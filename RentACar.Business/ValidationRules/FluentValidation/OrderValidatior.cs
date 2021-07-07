using FluentValidation;
using RentACar.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Business.ValidationRules.FluentValidation
{
    public class OrderValidatior : AbstractValidator<Order>
    {
        public OrderValidatior()
        {
            RuleFor(x => x.CustomerID).NotEmpty();
            RuleFor(x => x.DealerID).NotEmpty();
            RuleFor(x => x.TotalAmount).NotEmpty();
            RuleFor(x => x.VehicleID).NotEmpty();
        }
    }
}
