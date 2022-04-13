using Newtonsoft.Json;
using System.Net;
using ProductApi.Models;

namespace ProductApi.ProductRepo
{
    public class ProductOperations
    {
        public static List<Product> productList = new List<Product>();
        public void GetProducts()
        {
            if (productList.Count==0)
            {
                using (WebClient wc = new WebClient())
                {
                    var json = wc.DownloadString("https://northwind.vercel.app/api/products");
                    var products = JsonConvert.DeserializeObject<List<Product>>(json);
                    productList.AddRange(products);
                }
            }
        }
    }
}
