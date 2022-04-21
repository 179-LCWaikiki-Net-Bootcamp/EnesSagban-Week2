using ProductApi.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApi_BLL.Abstract
{
    public interface IBaseBLL<TEntity>
        where TEntity : BaseEntity
    {
        //Datalar ViewModel'ler ile taşınacağından bu kısım kullanılmadı.

        //TEntity Insert(TEntity entity);
        //TEntity Update(TEntity entity);
        //int Delete(TEntity entity);
        //int DeleteByID(int entityID);
        //TEntity Get(int entityID);
        //IList<TEntity> GetAll();

    }
}
