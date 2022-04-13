using Microsoft.AspNetCore.Mvc;
using ProductApi.Models;
using ProductApi.ProductRepo;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        ProductOperations productOperations;
        public ProductController()
        {
            productOperations = new ProductOperations();
        }
        // GET: api/<ProductController>
        [HttpGet]
        public List<Product> Get()
        { 
            productOperations.GetProducts();
            return ProductOperations.productList;
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public Product Get(int id)
        {
            return ProductOperations.productList.Find(x => x.id == id);
        }

        // POST api/<ProductController>
        [HttpPost]
        public void Post([FromBody] Product value)
        {
            ProductOperations.productList.Add(value);
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Product value)
        {
            Product product = ProductOperations.productList.Find(x => x.id == id);
            product.id = id;
            product.unitPrice = value.unitPrice;
            product.discontinued=value.discontinued;
            product.quantityPerUnit = value.quantityPerUnit;
            product.unitsOnOrder = value.unitsOnOrder;
            product.discontinued= value.discontinued;
            product.name = value.name;
            product.unitsInStock = value.unitsInStock;
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            ProductOperations.productList.Remove(ProductOperations.productList.Find(x => x.id == id));
        }
    }
}
