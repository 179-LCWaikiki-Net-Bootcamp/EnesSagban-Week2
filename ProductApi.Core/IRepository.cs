using ProductApi.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProductApi.Core
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        TEntity Get(Expression<Func<TEntity,bool>> filter=null , params Expression<Func<TEntity,object>>[] includes);
        TEntity Add(TEntity entity);
        TEntity Update(TEntity entity);
        int Delete(TEntity id);
        ICollection<TEntity> GetAll(Expression<Func<TEntity,bool>> filter=null , params Expression<Func<TEntity,object>>[] includes);
    }
}
