using Business.Abstract;
using Business.Constants;
using Core.CrossCuttingConcerns.Logging.Serilog.Loggers;
using Core.Utilities.Business;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using CRM.Core.Aspects.Autofac.Logging;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    [LogAspect(typeof(FileLogger))]
    public class OrderManager : IOrderService
    {
        private readonly IOrderDal _orderDal;
        private readonly IProductService _productService;
        private readonly ICustomerAddressService _customerAddressService;
        private readonly IBillingService _billingService;

        public OrderManager(IOrderDal orderDal, IProductService productService, ICustomerAddressService customerAddressService, IBillingService billingService)
        {
            _orderDal = orderDal;
            _productService = productService;
            _customerAddressService = customerAddressService;
            _billingService = billingService;
        }

        public IResult Add(OrderAddDto orderAddDto)
        {
            var result = BusinessRules.Run(
                _orderDal.IsProductInStock(orderAddDto.ProductId, orderAddDto.Quantity),
                CustomerHasAddress(orderAddDto.CustomerId)
                );
            if (result == null)
            {
                _orderDal.Add(new Order { CustomerId = orderAddDto.CustomerId, ProductId = orderAddDto.ProductId, Quantity = orderAddDto.Quantity });
                while (true)
                {
                    var order = _orderDal.GetList(x => x.CustomerId == orderAddDto.CustomerId && x.ProductId == orderAddDto.ProductId && x.Quantity == orderAddDto.Quantity).Last();
                    if (order != null)
                    {
                        var billing = _billingService.Add(new Billing { Discount = orderAddDto.Discount, Tax = orderAddDto.Tax, ItemPrice = orderAddDto.ItemPrice, TotalCost = orderAddDto.TotalCost, OrderId = order.OrderId });
                        order.BillingId = billing.Data.OrderId;
                        _orderDal.Update(order);
                        break;
                    }
                }
                _productService.StokReduction(orderAddDto.ProductId, orderAddDto.Quantity);
                return new SuccessResult(OrderMessages.OrderAdded);
            }
            return result;
        }

        private IResult CustomerHasAddress(string customerId)
        {
            return _customerAddressService.GetCustomerAddresses(customerId).Data.Count() > 0 ? new SuccessResult() : new ErrorResult("Müşteri adres bilgisi bulunamadı.");

        }
    }
}
