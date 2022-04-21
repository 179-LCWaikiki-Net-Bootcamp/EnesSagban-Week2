using Microsoft.AspNetCore.Mvc;
using ProductApi.ViewModel;
using ProductApi_BLL.Abstract;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EcommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        ICategoryBLL categoryService; //Program.cs de belirttiğimiz AddScoped metotu sayesinde bu şekilde
        //direkt ilgili servisin instance'ına, servis üzerinden de Repo'nun instance'ına ulaşırız.

        public CategoryController(ICategoryBLL categoryService)
        {
            this.categoryService = categoryService;
        }

        // GET: api/<CategoryController>
        [HttpGet]
        public IActionResult Get()
        {
            List<CategoryVM> categories = categoryService.GetAllCategories();
            if (ModelState.IsValid)
                return Ok(categories);
            else
                return BadRequest();
            //Database'den çekilen veri 'Valid' ise Ok([data]) datayı döner, değilse BadRequest döner.
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            CategoryVM category = categoryService.GetCategoryById(id);
            if (ModelState.IsValid)
                return Ok(category);
            else
                return BadRequest("Not Found !");
        }

        /// <summary>
        /// Category'lerden textbox'a girilen 'str' değerini içerenleri getiren api
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        // GET api/<CategoryController>/5
        [HttpGet("Search/{str}")]
        public IActionResult Filter(string str)
        {
            List<CategoryVM> category = categoryService.GetCategoryByFilter(str); //Contains olarak çalışır
            if (ModelState.IsValid)
                return Ok(category.Count() >0 ? category : "Girilen değer ile eşleşen sonuç bulunamadı.");
            else
                return BadRequest("Not Found !");
        }
        /// <summary>
        /// ID'si girilen category'nin içindeki 'Product' listesini getiren api
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("List/{id}")]
        public IActionResult GetProductsInCategory(int id)
        {
            List<ProductVM> products = categoryService.GetProductsInCategory(id);
            if (ModelState.IsValid)
                return Ok(products.Count > 0 ? products : "Girilen değer ile eşleşen sonuç bulunamadı.");
            else
                return BadRequest("Not Found !");
        }

        // POST api/<CategoryController>
        [HttpPost]
        public IActionResult Post([FromBody] CategoryVM category)
        {
            category.ID = 0;
            CategoryVM insertCategory = categoryService.CreateCategory(category);
            if (ModelState.IsValid)
                return Ok($"{insertCategory.Name} adding was successful.");
            else
                return BadRequest("Not added !");
        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] CategoryVM updateCategory)
        {
            CategoryVM updatedCategory = categoryService.UpdateCategory(updateCategory);
            if (ModelState.IsValid)
                return Ok(updatedCategory);
            else
                return BadRequest("Not updated !");
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (categoryService.DeleteCategory(id) > 0)
                return Ok();
            return BadRequest("Not deleted !");
        }
    }
}
