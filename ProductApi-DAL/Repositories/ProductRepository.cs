using Newtonsoft.Json;
using System.Net;
using ProductApi.Models;
using ProductApi.Core.Entity;
using ProductApi_DAL.Abstract;
using ProductApi.Core.EntityFramework;
using ProductApi_DAL;

namespace ProductApi_DAL.ProductRepositories
{
    public class ProductRepository : EFRepositoryBase<Product, ProductDbContext>,IProductDAL
    {
        public ProductRepository(ProductDbContext context) : base(context)
        {
        }

        //public static List<Product> productList = new List<Product>();
        //public void GetProducts()
        //{
        //    if (productList.Count==0)
        //    {
        //        using (WebClient wc = new WebClient())
        //        {
        //            var json = wc.DownloadString("https://northwind.vercel.app/api/products");
        //            var products = JsonConvert.DeserializeObject<List<Product>>(json);
        //            productList.AddRange(products);
        //        }
        //    }
        //}

    }
}
