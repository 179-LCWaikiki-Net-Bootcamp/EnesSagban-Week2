using Microsoft.AspNetCore.Mvc;
using ProductApi.ViewModel;
using ProductApi_BLL.Abstract;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EcommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        IProductBLL productService;

        public ProductController(IProductBLL productService)
        {
            this.productService = productService;
        }

        // GET: api/<ProductController>
        [HttpGet]
        public IActionResult Get()
        {
            List<ProductVM> products = productService.GetAllProducts();
            if (ModelState.IsValid)
                return Ok(products);
            else
                return BadRequest();
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var product=productService.GetProductById(id);
            if (ModelState.IsValid)
                return Ok(product);
            else
                return BadRequest("Not Found !");
        }

        [HttpGet("Search/{str}")]
        public IActionResult Filter(string str)
        {
            List<ProductVM> product = productService.GetProductByFilter(str); //Contains olarak çalışır
            if (ModelState.IsValid)
                return Ok(product.Count() > 0 ? product : "Girilen değer ile eşleşen sonuç bulunamadı.");
            else
                return BadRequest("Not Found !");
        }

        // POST api/<ProductController>
        [HttpPost]
        public IActionResult Post([FromBody] ProductVM product)
        {
            ProductVM insertProduct = productService.CreateProduct(product);
            if (ModelState.IsValid)
                return Ok($"{insertProduct.Name} adding was successful.");
            else
                return BadRequest("Not added !");
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] ProductVM updateProduct)
        {
            ProductVM updatedProduct =productService.UpdateProduct(updateProduct);
            if (ModelState.IsValid)
                return Ok(updatedProduct);
            else
                return BadRequest("Not updated !");
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (productService.DeleteProduct(id) > 0)
                return Ok();
            return BadRequest("Not deleted !");
        }
    }
}
