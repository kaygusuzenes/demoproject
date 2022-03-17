using Core.Utilities.Results.Abstract;
using CRM.Core.DataAccess;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IOrderDal:IEntityRepositoryBase<Order>
    {
        IResult IsProductInStock(int productId,int quantity);
    }
}
