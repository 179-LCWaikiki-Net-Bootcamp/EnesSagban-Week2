using Microsoft.AspNetCore.Mvc;
using ProductApi.ViewModel;
using ProductApi_BLL.Abstract;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EcommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        ISupplierBLL supplierService;

        public SupplierController(ISupplierBLL supplierService)
        {
            this.supplierService = supplierService;
        }

        // GET: api/<SupplierController>
        [HttpGet]
        public IActionResult Get()
        {
            List<SupplierVM> suppliers = supplierService.GetAllSuppliers();
            if (ModelState.IsValid)
                return Ok(suppliers);
            else
                return BadRequest();
        }

        // GET api/<SupplierController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            SupplierVM supplier = supplierService.GetSupplierById(id);
            if (ModelState.IsValid)
                return Ok(supplier);
            else
                return BadRequest("Not Found !");
        }

        [HttpGet("Search/{str}")]
        public IActionResult Filter(string str)
        {
            List<SupplierVM> supplier = supplierService.GetSupplierByFilter(str); //ContactName'e göre filtreler
            if (ModelState.IsValid)
                return Ok(supplier.Count() > 0 ? supplier : "Girilen değer ile eşleşen sonuç bulunamadı.");
            else
                return BadRequest("Not Found !");
        }

        /// <summary>
        /// ID'si girilen supplier'ın tedarik ettiği 'Product' listesini getiren api
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("List/{id}")]
        public IActionResult GetProductsInCategory(int id)
        {
            List<ProductVM> products = supplierService.GetProductsInCategory(id);
            if (ModelState.IsValid)
                return Ok(products.Count > 0 ? products : "Girilen değer ile eşleşen sonuç bulunamadı.");
            else
                return BadRequest("Not Found !");
        }

        // POST api/<SupplierController>
        [HttpPost]
        public IActionResult Post([FromBody] SupplierVM supplier)
        {
            SupplierVM insertSupplier = supplierService.CreateSupplier(supplier);
            if (ModelState.IsValid)
                return Ok($"{insertSupplier.ContactName} adding was successful.");
            else
                return BadRequest("Not added !");
        }

        // PUT api/<SupplierController>/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] SupplierVM updateSupplier)
        {
            SupplierVM updatedSupplier = supplierService.UpdateSupplier(updateSupplier);
            if (ModelState.IsValid)
                return Ok(updatedSupplier);
            else
                return BadRequest("Not updated !");
        }

        // DELETE api/<SupplierController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (supplierService.DeleteSupplier(id) > 0)
                return Ok();
            return BadRequest("Not deleted !");
        }
    }
}
