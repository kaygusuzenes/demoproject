using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillingsController : ControllerBase
    {
        private readonly IBillingService _billingService;

        public BillingsController(IBillingService billingService)
        {
            _billingService = billingService;
        }

        [HttpPost("addbilling")]
        public IActionResult AddBilling(Billing billing)
        {
            var result=_billingService.Add(billing);
            return result.Success ? Ok(result.Message) : BadRequest(result.Message);
        }
    }
}
