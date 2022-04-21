using ProductApi.Models;
using ProductApi.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApi_BLL.Abstract
{
    public interface IProductBLL
    {
        ProductVM GetProductById(int id);
        List<ProductVM> GetAllProducts();
        ProductVM CreateProduct(ProductVM product);
        ProductVM UpdateProduct(ProductVM updatedProduct);
        int DeleteProduct(int id);
        List<ProductVM> GetProductByFilter(string str);
    }
}
