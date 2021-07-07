using FluentValidation;
using RentACar.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Business.ValidationRules.FluentValidation
{
    public class CountryValidatior:AbstractValidator<Country>
    {
        public CountryValidatior()
        {
            //BURADA VERİTABANINI AÇARAK ORDAKİ ÖZELLİKLERE GÖRE BURALARA KURALLARI OLUŞTURMAMIZ LAZIM
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Name).Length(5,20);
        }
    }
}
