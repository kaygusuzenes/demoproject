using Business.Abstract;
using Business.Constants;
using Core.CrossCuttingConcerns.Logging.Serilog.Loggers;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using CRM.Core.Aspects.Autofac.Logging;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    [LogAspect(typeof(FileLogger))]
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public IResult Add(Product product)
        {
            _productDal.Add(product);
            return new SuccessResult(ProductMessages.ProductAdded);
        }

        public IDataResult<List<Product>> GetAll()
        {
            var data = _productDal.GetList();
            return new SuccessDataResult<List<Product>>(data: data, message: ProductMessages.ProductsListed);
        }

        public IResult StokReduction(int productId, int quantity)
        {
            var entity = _productDal.Get(x => x.ProductId == productId);
            entity.Stock = entity.Stock - quantity;
            _productDal.Update(entity);
            return new SuccessResult();
        }
    }
}
