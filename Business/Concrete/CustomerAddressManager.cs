using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entity.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class CustomerAddressManager : ICustomerAddressService
    {
        private readonly ICustomerAddressDal _customerAddressDal;

        public CustomerAddressManager(ICustomerAddressDal customerAddressDal)
        {
            _customerAddressDal = customerAddressDal;
        }

        public IResult Add(CustomerAddress customerAddress)
        {
            _customerAddressDal.Add(customerAddress);
            return new SuccessResult(CustomerMessages.CustomerAddressAdded);
        }

        public IDataResult<List<CustomerAddress>> GetCustomerAddresses(string customerId)
        {
            var data = _customerAddressDal.GetList(c=>c.CustomerId==customerId);
            return new SuccessDataResult<List<CustomerAddress>>(data: data, message: CustomerMessages.CustomerAddressesListed);
        }
    }

}
