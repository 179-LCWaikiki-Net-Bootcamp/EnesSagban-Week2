using Newtonsoft.Json;
using ProductApi.Models;
using System.Net;

namespace ProductApi.ProductRepo
{
    public class CategoryOperations
    {
        public static List<Category> categoryList = new List<Category>();
        public void GetCategories()
        {
            if (categoryList.Count==0)
            {
                using (WebClient wc = new WebClient())
                {
                    var json = wc.DownloadString("https://northwind.vercel.app/api/categories");
                    var categories = JsonConvert.DeserializeObject<List<Category>>(json);
                    categoryList.AddRange(categories);
                }
            }
        }
    }
}
