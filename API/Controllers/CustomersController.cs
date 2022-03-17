using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly ICustomerAddressService _customerAddressService;

        public CustomersController(ICustomerService customerService, ICustomerAddressService customerAddressService)
        {
            _customerService = customerService;
            _customerAddressService = customerAddressService;
        }

        [HttpPost("addcustomer")]
        public IActionResult AddCustomer(Customer customer)
        {
            var result = _customerService.Add(customer);
            return result.Success ? Ok(result.Message) : BadRequest(result.Message);
        }

        [HttpGet("getcustomers")]
        public IActionResult GetCustomers()
        {
            var result = _customerService.GetAll();
            return result.Success?Ok(result):BadRequest(result.Message);    
        }

        [HttpPost("addcustomeraddress")]
        public IActionResult AddCustomerAddress(CustomerAddress customerAddress)
        {
            var result = _customerAddressService.Add(customerAddress);
            return result.Success?Ok(result.Message):BadRequest(result.Message);
        }

        [HttpGet("getcustomeraddresses")]
        public IActionResult GetCustomerAddresses(string customerId)
        {
            var result=_customerAddressService.GetCustomerAddresses(customerId);
            return result.Success ? Ok(result) : BadRequest(result.Message);
        }

    }
}
