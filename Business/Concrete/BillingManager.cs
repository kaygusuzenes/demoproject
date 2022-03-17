using Business.Abstract;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entity.Concrete;

namespace Business.Concrete
{
    public class BillingManager : IBillingService
    {
        private readonly IBillingDal _billingDal;

        public BillingManager(IBillingDal billingDal)
        {
            _billingDal = billingDal;
        }

        public IResult Add(Billing billing)
        {
            _billingDal.Add(billing);
            return new SuccessResult();
        }
    }
}
