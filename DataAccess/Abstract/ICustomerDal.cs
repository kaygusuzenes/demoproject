using CRM.Core.DataAccess;
using Entity.Concrete;

namespace DataAccess.Abstract
{
    public interface ICustomerDal : IEntityRepositoryBase<Customer> { }
}
