using Microsoft.AspNetCore.Mvc;
using ProductApi.Models;
using ProductApi.ProductRepo;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        CategoryOperations categoryOperations;
        public CategoryController()
        {
            categoryOperations = new CategoryOperations();
        }
        // GET: api/<CategoryController>
        [HttpGet]
        public List<Category> Get()
        {
            categoryOperations.GetCategories();
            return CategoryOperations.categoryList ;
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public Category Get(int id)
        {
            return CategoryOperations.categoryList.Find(x=>x.id==id);
        }

        // POST api/<CategoryController>
        [HttpPost]
        public void Post([FromBody] Category value)
        {
            CategoryOperations.categoryList.Add(value);
        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Category value)
        {
            //CategoryOperations.categoryList.Where(x=>x.id==id).ToList().ForEach(x=>x.description=value.description);
            //foreach (var item in CategoryOperations.categoryList.ToList())
            //{
            //    if (item.id==id)
            //    {
            //        item.description = value.description;
            //        item.name= value.name;
            //    }
            //}
            Category category=CategoryOperations.categoryList.Find(x => x.id == id);
            category.description= value.description;
            category.name= value.name;
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            CategoryOperations.categoryList.Remove(CategoryOperations.categoryList.Find(x => x.id == id));
        }
    }
}
