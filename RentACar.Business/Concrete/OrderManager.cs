using AutoMapper;
using RentACar.Business.Abstract;
using RentACar.Business.Contants;
using RentACar.Business.ValidationRules.FluentValidation;
using RentACar.Core.Aspects.Autofac;
using RentACar.Core.Aspects.Autofac.Exception;
using RentACar.Core.Aspects.Autofac.Logging;
using RentACar.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using RentACar.Core.Utilities.Results;
using RentACar.Core.Utilities.Results.Abstract;
using RentACar.Core.Utilities.Results.Concrete;
using RentACar.Core.Utilities.SMTP;
using RentACar.DataAccess.Abstract;
using RentACar.Entities.Concrete;
using RentACar.Entities.Dtos.Add;
using RentACar.Entities.Dtos.Get;
using RentACar.Entities.Dtos.Update;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Business.Concrete
{
    [ExceptionLogAspect(typeof(FileLoggerException))]
    [LogAspect(typeof(FileLogger))]
    public class OrderManager : IOrderService
    {
        private IOrderDal _orderDal;
        private IInvoiceService _invoiceService;
        private ICustomerService _customerService;
        private readonly IMapper _mapper;

        public OrderManager(
            IOrderDal orderDal, 
            IMapper mapper,
            IInvoiceService invoiceService,
            ICustomerService customerService)
        {
            _orderDal = orderDal;
            _invoiceService = invoiceService;
            _mapper = mapper;
            _customerService = customerService;
        }

        [ValidationAspect(typeof(OrderValidatior))]
        public IDataResult<OrderGetDto> Add(OrderAddDto entity)
        {
            try
            {
                var days = (entity.EndDate - entity.StartingDate).TotalDays;
                entity.TotalAmount *= days ;
                var addedOrder = _mapper.Map<Order>(entity);
                _orderDal.Add(addedOrder);
                var getAdd = _orderDal.GetList().LastOrDefault();

                var getEntity = _mapper.Map<OrderGetDto>(getAdd);
                var invoiceEntity = _invoiceService.Add(new InvoiceAddDto
                {
                    InvoiceDate = DateTime.Now,
                    OrderID = getAdd.ID,
                    TotalPrice = Convert.ToInt32( getAdd.TotalAmount ),
                    EmployeeID = 1
                }).Data;

                var customerEntity = _customerService.GetById(getAdd.CustomerID).Data;
                string mailSubject = "Sipariş Bilgileri";
                string mailBody = $"Merhaba sayın {customerEntity.Name} {customerEntity.Surname.ToUpper()}...<br/><br/>" +
                    $"{invoiceEntity.InvoiceDate} tarihli araç kiralama işleminiz tamamlanmıştır.<br/><br/>"+
                    $"Sipariş numarası: {getAdd.ID}<br/>" +
                    $"Fatura numarası: {invoiceEntity.ID}<br/>" +
                    $"Başlangıç tarihi: {getAdd.StartingDate}<br/>" +
                    $"Bitiş tarihi: {getAdd.EndDate}<br/>" +
                    $"Toplam tutar: {getAdd.TotalAmount}<br/>";

                MailHelper.SendMail(
                    customerEntity.Email,
                    mailSubject,
                    mailBody);
                return new SuccessDataResult<OrderGetDto>(getEntity, Messages.SuccessfullyAdded);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<OrderGetDto>(Messages.AnErrorOccurred + " | " + e.Message);
            }
        }

        public IResult Delete(int id)
        {
            try
            {
                var entity = _orderDal.Get(c => c.ID == id);
                if (entity == null)
                {
                    return new ErrorResult(Messages.NotFound);
                }
                _orderDal.Delete(entity);
                return new SuccessResult(Messages.SuccessfullyDeleted);
            }
            catch (Exception e)
            {
                return new ErrorResult(Messages.AnErrorOccuredOnDeletion + " | " + e.Message);
            }
        }

        public IDataResult<OrderGetDto> GetById(int id)
        {
            try
            {
                var entity = _orderDal.Get(p => p.ID == id);
                if (entity == null)
                {
                    return new ErrorDataResult<OrderGetDto>(Messages.NotFound);
                }

                var getOrder = _mapper.Map<OrderGetDto>(entity);
                return new SuccessDataResult<OrderGetDto>(getOrder);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<OrderGetDto>(Messages.AnErrorOccurred + " | " + e.Message);
            }
        }

        public IDataResult<IList<OrderGetDto>> GetList()
        {
            try
            {
                var getList = _orderDal.GetList();
                var getListOrder = _mapper.Map<List<OrderGetDto>>(getList);
                return new SuccessDataResult<List<OrderGetDto>>(getListOrder);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<List<OrderGetDto>>(Messages.AnErrorOccurred + " | " + e.Message);
            }
        }

        [ValidationAspect(typeof(OrderValidatior))]
        public IResult Update(OrderUpdateDto entity)
        {
            try
            {
                var update = _orderDal.Get(a => a.ID == entity.ID);
                if (update == null)
                {
                    return new ErrorResult(Messages.NotFound);
                }
                var updatedOrder = _mapper.Map<OrderUpdateDto, Order>(entity, update);
                _orderDal.Update(updatedOrder);

                return new SuccessResult(Messages.SuccessfullyUpdated);
            }
            catch (Exception e)
            {
                return new ErrorResult(Messages.AnErrorOccuredOnUpdation + " | " + e.Message);
            }
        }
    }
}
