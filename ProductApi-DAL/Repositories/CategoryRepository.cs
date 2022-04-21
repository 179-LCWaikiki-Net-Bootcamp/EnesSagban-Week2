using Newtonsoft.Json;
using ProductApi.Core.Entity;
using ProductApi.Core.EntityFramework;
using ProductApi.Models;
using ProductApi_DAL;
using ProductApi_DAL.Abstract;
using System.Net;

namespace ProductApi_DAL.ProductRepositories
{
    public class CategoryRepository : EFRepositoryBase<Category, ProductDbContext>, ICategoryDAL
    {
        public CategoryRepository(ProductDbContext context) : base(context)
        {
        }
    }
}
