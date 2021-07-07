using FluentValidation;
using RentACar.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Business.ValidationRules.FluentValidation
{
    public class OrderItemValidatior : AbstractValidator<OrderItem>
    {
        public OrderItemValidatior()
        {
            RuleFor(x => x.Cost).NotEmpty();
            RuleFor(x => x.OrderID).NotEmpty();
            RuleFor(x => x.Quantity).NotEmpty();
            RuleFor(x => x.VehicleID).NotEmpty();
        }
    }
}
