using AutoMapper;
using ProductApi.Models;
using ProductApi.ViewModel;
using ProductApi_BLL.Abstract;
using ProductApi_DAL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApi_BLL.Services
{
    public class CategoryService : ICategoryBLL
    {
        IMapper mapper;
        ICategoryDAL categoryDAL;
        IProductDAL productDAL;

        public CategoryService(ICategoryDAL categoryDAL, IMapper mapper, IProductDAL productDAL)
        {
            this.categoryDAL = categoryDAL;
            this.mapper = mapper;
            this.productDAL = productDAL;
        }
        public List<CategoryVM> GetAllCategories()
        {
            return mapper.Map<List<CategoryVM>>(categoryDAL.GetAll().ToList());
        }
        public CategoryVM GetCategoryById(int id)
        {
            Category category = categoryDAL.Get(x => x.id == id, x => x.Products);
            CategoryVM vm = mapper.Map<CategoryVM>(category);
            return vm;
        }
        public List<ProductVM> GetProductsInCategory(int id)
        {
            //Category category = categoryDAL.Get(x => x.id == id, x => x.Products); //LazyLoading kullanılmadığı için Supplier bilgilerine kadar ulaşılmıyor şimdilik aşağıda farklı yöntem kullanılacak.
            List<Product> products = productDAL.GetAll(x=>x.categoryId==id,x=>x.Supplier,x=>x.Category).ToList();
            List<ProductVM> vm = mapper.Map<List<ProductVM>>(products);
            return vm;
        }
        public CategoryVM CreateCategory(CategoryVM category)
        {
            return mapper.Map<CategoryVM>(categoryDAL.Add(mapper.Map<Category>(category))); 
            //VM alınıp Entity olarak Create edilip sonra tekrar VM döneceği için 2 kez Map yapıldı.
        }
        public CategoryVM UpdateCategory(CategoryVM updateCategory)
        {
            return mapper.Map<CategoryVM>(categoryDAL.Update(mapper.Map<Category>(updateCategory)));
            //VM alınıp Entity olarak Update edilip sonra tekrar VM döneceği için 2 kez Map yapıldı.
        }
        public int DeleteCategory(int id)
        {
            Category deleteCategory = categoryDAL.Get(x => x.id == id);
            if (deleteCategory!=null)
                return categoryDAL.Delete(deleteCategory);
            return 0;
        }

        public List<CategoryVM> GetCategoryByFilter(string str)
        {
            return mapper.Map<List<CategoryVM>>(categoryDAL.GetAll(x => x.name.Contains(str)).ToList());
        }

       
    }
}
