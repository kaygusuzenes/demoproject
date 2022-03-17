using Core.Utilities.Results.Abstract;
using Entity.Concrete;

namespace Business.Abstract
{
    public interface IBillingService
    {
        IDataResult<Billing> Add(Billing billing);
    }

}
