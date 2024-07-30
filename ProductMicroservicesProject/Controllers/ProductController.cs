using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Writers;
using ProductMicroservicesProject.Models;
using ProductMicroservicesProject.Repository;
using System.Transactions;

namespace ProductMicroservicesProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var products = _productRepository.GetProducts();
            return new OkObjectResult(products);
        }

        [HttpGet("{Id}", Name = ("Get"))]
        public IActionResult Get(int id)
        {
            var products = _productRepository.GetProductById(id);
            return new OkObjectResult(products);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Products products)
        {
            _productRepository.InsertProduct(products);
            return CreatedAtAction(nameof(Get), new { id = products.Id });
        }

        [HttpPut]
        public IActionResult Put([FromBody] Products products)
        {
            if (products != null)
            {
                using (var scope = new TransactionScope())
                {
                    _productRepository.UpdateProduct(products);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _productRepository.DeleteProduct(id);
            return new OkResult();
        }
    }
}