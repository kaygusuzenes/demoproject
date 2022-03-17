using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost("addproduct")]
        public IActionResult AddProduct(Product product)
        {
            var result = _productService.Add(product);
            return result.Success ? Ok(result.Message) : BadRequest(result.Message);
        }

        [HttpGet("getproducts")]
        public IActionResult GetProducts()
        {
            var result = _productService.GetAll();
            return result.Success ? Ok(result) : BadRequest(result.Message);
        }
    }
}
