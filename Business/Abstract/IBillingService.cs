using Core.Utilities.Results.Abstract;
using Entity.Concrete;

namespace Business.Abstract
{
    public interface IBillingService
    {
        IResult Add(Billing billing);
    }

}
