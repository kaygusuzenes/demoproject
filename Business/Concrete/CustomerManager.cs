using Business.Abstract;
using Business.Constants;
using Core.CrossCuttingConcerns.Logging.Serilog.Loggers;
using Core.Utilities.Business;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using CRM.Core.Aspects.Autofac.Logging;
using DataAccess.Abstract;
using Entity.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    [LogAspect(typeof(FileLogger))]
    public class CustomerManager : ICustomerService
    {
        private readonly ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public IResult Add(Customer customer)
        {
            var result = BusinessRules.Run(IsAnyCustomer(customer.EmailAddress));
            if (result == null)
            {
                _customerDal.Add(customer);
                return new SuccessResult(CustomerMessages.CustomerAdded);
            }
            return result;
        }

        IResult IsAnyCustomer(string emailAddress)
        {
            var control = _customerDal.Get(x => x.EmailAddress == emailAddress);
            return control == null ? new SuccessResult() : new ErrorResult(CustomerMessages.CustomerAlreadyAdded);
        }

        public IDataResult<List<Customer>> GetAll()
        {
            var data = _customerDal.GetList();
            return new SuccessDataResult<List<Customer>>(data: data, message: CustomerMessages.CustomersListed);
        }
    }

}
