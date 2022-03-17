using Business.Abstract;
using Core.CrossCuttingConcerns.Logging.Serilog.Loggers;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using CRM.Core.Aspects.Autofac.Logging;
using DataAccess.Abstract;
using Entity.Concrete;

namespace Business.Concrete
{
    [LogAspect(typeof(FileLogger))]
    public class BillingManager : IBillingService
    {
        private readonly IBillingDal _billingDal;

        public BillingManager(IBillingDal billingDal)
        {
            _billingDal = billingDal;
        }

        public IDataResult<Billing> Add(Billing billing)
        {
            _billingDal.Add(billing);
            while (true)
            {
                var data = _billingDal.Get(x => x.OrderId == billing.OrderId);
                if (data != null)
                {
                    return new SuccessDataResult<Billing>(data);
                }
            }
        }
    }
}
