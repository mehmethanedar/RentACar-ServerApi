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
    public class InvoiceManager : IInvoiceService
    {
        private IInvoiceDal _invoiceDal;
        private readonly IMapper _mapper;

        public InvoiceManager(IInvoiceDal invoiceDal, IMapper mapper)
        {
            _invoiceDal = invoiceDal;
            _mapper = mapper;
        }
        [ValidationAspect(typeof(InvoiceValidatior))]
        public IDataResult<InvoiceGetDto> Add(InvoiceAddDto entity)
        {
            try
            {
                var addedInvoice = _mapper.Map<Invoice>(entity);
                _invoiceDal.Add(addedInvoice);
                var getAdd = _invoiceDal.GetList().LastOrDefault();

                var getEntity = _mapper.Map<InvoiceGetDto>(getAdd);
                return new SuccessDataResult<InvoiceGetDto>(getEntity, Messages.SuccessfullyAdded);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<InvoiceGetDto>(Messages.AnErrorOccurred + " | " + e.Message);
            }
        }

        public IResult Delete(int id)
        {
            try
            {
                var entity = _invoiceDal.Get(c => c.ID == id);
                if (entity == null)
                {
                    return new ErrorResult(Messages.NotFound);
                }
                _invoiceDal.Delete(entity);
                return new SuccessResult(Messages.SuccessfullyDeleted);
            }
            catch (Exception e)
            {
                return new ErrorResult(Messages.AnErrorOccuredOnDeletion + " | " + e.Message);
            }
        }

        public IDataResult<InvoiceGetDto> GetById(int id)
        {
            try
            {
                var entity = _invoiceDal.Get(p => p.ID == id);
                if (entity == null)
                {
                    return new ErrorDataResult<InvoiceGetDto>(Messages.NotFound);
                }

                var getInvoice = _mapper.Map<InvoiceGetDto>(entity);
                return new SuccessDataResult<InvoiceGetDto>(getInvoice);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<InvoiceGetDto>(Messages.AnErrorOccurred + " | " + e.Message);
            }
        }

        public IDataResult<IList<InvoiceGetDto>> GetList()
        {
            try
            {
                var getList = _invoiceDal.GetList();
                var getListInvoice = _mapper.Map<List<InvoiceGetDto>>(getList);
                return new SuccessDataResult<List<InvoiceGetDto>>(getListInvoice);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<List<InvoiceGetDto>>(Messages.AnErrorOccurred + " | " + e.Message);
            }
        }

        [ValidationAspect(typeof(InvoiceValidatior))]
        public IResult Update(InvoiceUpdateDto entity)
        {
            try
            {
                var update = _invoiceDal.Get(a => a.ID == entity.ID);
                if (update == null)
                {
                    return new ErrorResult(Messages.NotFound);
                }
                var updatedInvoice = _mapper.Map<InvoiceUpdateDto, Invoice>(entity, update);
                _invoiceDal.Update(updatedInvoice);

                return new SuccessResult(Messages.SuccessfullyUpdated);
            }
            catch (Exception e)
            {
                return new ErrorResult(Messages.AnErrorOccuredOnUpdation + " | " + e.Message);
            }
        }
    }
}
