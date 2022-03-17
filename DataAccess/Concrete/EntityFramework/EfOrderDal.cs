using Core.DataAccess.EntityFramework;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfOrderDal : EfEntityRepositoryBase<Order, KotonContext>, IOrderDal
    {
        public IResult IsProductInStock(int productId, int quantity)
        {
            using (KotonContext context=new KotonContext())
            {
                var status = context.Products.Any(p => p.ProductId == productId && p.Stock >= quantity);
                return status ? new SuccessResult() : new ErrorResult("Üründe yeterli stok yok.");
            }
        }
    }
}
