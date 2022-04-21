using ProductApi.Core;
using ProductApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApi_DAL.Abstract
{
    public interface ICategoryDAL : IRepository<Category> //ICategory interface'i ile temel generic metotların,
                                                          //'Category' classı için uygulanacağını belirttik.
    {
    }
}
