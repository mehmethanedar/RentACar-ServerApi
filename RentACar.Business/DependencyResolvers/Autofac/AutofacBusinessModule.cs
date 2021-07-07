using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using log4net;
using RentACar.Business.Abstract;
using RentACar.Business.Concrete;
using RentACar.Core.CrossCuttingConcerns.Logging.Log4Net;
using RentACar.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using RentACar.Core.Utilities.Interceptors;
using RentACar.Core.Utilities.Security.Jwt;
using RentACar.DataAccess.Abstract;
using RentACar.DataAccess.Concrete;
using RentACar.DataAccess.Concrete.EntityFramework.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AddressManager>().As<IAddressService>();
            builder.RegisterType<EfAddressDal>().As<IAddressDal>();

            builder.RegisterType<CaseTypeManager>().As<ICaseTypeService>();
            builder.RegisterType<EfCaseTypeDal>().As<ICaseTypeDal>();

            builder.RegisterType<CityManager>().As<ICityService>();
            builder.RegisterType<EfCityDal>().As<ICityDal>();

            builder.RegisterType<ColorManager>().As<IColorService>();
            builder.RegisterType<EfColorDal>().As<IColorDal>();

            builder.RegisterType<CompanyManager>().As<ICompanyService>();
            builder.RegisterType<EfCompanyDal>().As<ICompanyDal>();

            builder.RegisterType<CountryManager>().As<ICountryService>();
            builder.RegisterType<EfCountryDal>().As<ICountryDal>();

            builder.RegisterType<CustomerManager>().As<ICustomerService>();
            builder.RegisterType<EfCustomerDal>().As<ICustomerDal>();

            builder.RegisterType<DealerManager>().As<IDealerService>();
            builder.RegisterType<EfDealerDal>().As<IDealerDal>();

            builder.RegisterType<DistrictManager>().As<IDistrictService>();
            builder.RegisterType<EfDistrictDal>().As<IDistrictDal>();

            builder.RegisterType<DriverLicenceManager>().As<IDriverLicenceService>();
            builder.RegisterType<EfDriverLicenceDal>().As<IDriverLicenceDal>();

            builder.RegisterType<EmployeeManager>().As<IEmployeeService>();
            builder.RegisterType<EfEmployeeDal>().As<IEmployeeDal>();

            builder.RegisterType<FuelTypeManager>().As<IFuelTypeService>();
            builder.RegisterType<EfFuelTypeDal>().As<IFuelTypeDal>();

            builder.RegisterType<GearTypeManager>().As<IGearTypeService>();
            builder.RegisterType<EfGearTypeDal>().As<IGearTypeDal>();

            builder.RegisterType<InvoiceManager>().As<IInvoiceService>();
            builder.RegisterType<EfInvoiceDal>().As<IInvoiceDal>();

            builder.RegisterType<OrderItemManager>().As<IOrderItemService>();
            builder.RegisterType<EfOrderItemDal>().As<IOrderItemDal>();

            builder.RegisterType<OrderManager>().As<IOrderService>();
            builder.RegisterType<EfOrderDal>().As<IOrderDal>();

            builder.RegisterType<PaymentManager>().As<IPaymentService>();
            builder.RegisterType<EfPaymentDal>().As<IPaymentDal>();

            builder.RegisterType<PaymentTypeManager>().As<IPaymentTypeService>();
            builder.RegisterType<EfPaymentTypeDal>().As<IPaymentTypeDal>();

            builder.RegisterType<TownManager>().As<ITownService>();
            builder.RegisterType<EfTownDal>().As<ITownDal>();

            builder.RegisterType<VehicleManager>().As<IVehicleService>();
            builder.RegisterType<EfVehicleDal>().As<IVehicleDal>();

            builder.RegisterType<VehicleBrandManager>().As<IVehicleBrandService>();
            builder.RegisterType<EfVehicleBrandDal>().As<IVehicleBrandDal>();

            builder.RegisterType<VehicleCategoryManager>().As<IVehicleCategoryService>();
            builder.RegisterType<EfVehicleCategoryDal>().As<IVehicleCategoryDal>();

            builder.RegisterType<VehicleModelManager>().As<IVehicleModelService>();
            builder.RegisterType<EfVehicleModelDal>().As<IVehicleModelDal>();

            builder.RegisterType<UserInformationManager>().As<IUserInformationService>();
            builder.RegisterType<EfUserInformationDal>().As<IUserInformationDal>();


            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();

            builder.RegisterType<FileLogger>().As<LoggerServiceBase>();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
