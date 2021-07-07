using System;
using Autofac;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Business.DependencyResolvers.Autofac
{
    public class AutofacAutoMapperModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(a => CreateConfiguration()).As<IMapper>();
        }
        private IMapper CreateConfiguration()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddMaps(GetType().Assembly);
            });
            return config.CreateMapper();
        }
    }
}
