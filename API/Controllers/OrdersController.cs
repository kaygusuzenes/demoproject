using Business.Abstract;
using Entity.Concrete;
using Entity.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost("addorder")]
        public IActionResult AddOrder(OrderAddDto orderAddDto)
        {
            var result=_orderService.Add(orderAddDto);
            return result.Success?Ok(result.Message):BadRequest(result.Message);
        }

    }
}
