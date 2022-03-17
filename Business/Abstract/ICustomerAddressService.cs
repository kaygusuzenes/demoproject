using Core.Utilities.Results.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICustomerAddressService
    {
        IResult Add(CustomerAddress customerAddress);
        IDataResult<List<CustomerAddress>> GetCustomerAddresses(string customerId);
    }
}
