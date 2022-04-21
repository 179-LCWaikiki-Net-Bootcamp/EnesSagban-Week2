using ProductApi.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApi_BLL.Abstract
{
    public interface ICategoryBLL 
    {
        /// <summary>
        /// Category ile ilgili BLL metotlarının tanımlandığı interface. 
        /// 'ICategoryBLL'den kalıtım alacak Service'de implement edilmek zorunda.
        /// </summary>
        /// <returns></returns>
        List<CategoryVM> GetAllCategories();
        CategoryVM GetCategoryById(int id);
        CategoryVM CreateCategory(CategoryVM category);
        CategoryVM UpdateCategory(CategoryVM updateCategory);
        int DeleteCategory(int id);
        List<CategoryVM> GetCategoryByFilter(string str);
        List<ProductVM> GetProductsInCategory(int id);
    }
}
