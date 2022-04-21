using Microsoft.EntityFrameworkCore;
using ProductApi.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProductApi.Core.EntityFramework
{
    public class EFRepositoryBase<TEntity, TContext> : IRepository<TEntity>
        where TEntity : BaseEntity
        where TContext : DbContext
    {
        /// <summary>
        /// IRepository'de tanımlanan Generic Metotların implemantasyon class'ı
        /// </summary>
        TContext context;
        public EFRepositoryBase(TContext context)
        {
            this.context = context; 
        }
        public TEntity Add(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Added;
            if (context.SaveChanges()>0)
                return entity;
            return null;
        }
        public TEntity Update(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            if (context.SaveChanges() > 0)
                return entity;
            return null;
        }

        public int Delete(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Deleted;
            return context.SaveChanges();
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includes)
        {
            return context.Set<TEntity>().Where(filter).MyInclude(includes).SingleOrDefault();
        }

        public ICollection<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includes)
        {
            if (filter == null)
            {
                return context.Set<TEntity>().MyInclude(includes).ToList();
            }
            else
            {
                return context.Set<TEntity>().Where(filter).MyInclude(includes).ToList();
            }
        }
    }
   
    public static class QuerableExtension
    {
        //Birden fazla include'u generic şekilde oluşturmak için yazılan extension metot
        public static IQueryable<T> MyInclude<T>(this IQueryable<T> query, params Expression<Func<T, object>>[] includes)
            where T : class
        {
            if (includes != null)
            {
                query = includes.Aggregate(query, (a, b) => a.Include(b));
            }
            return query;
        }
    }
}
