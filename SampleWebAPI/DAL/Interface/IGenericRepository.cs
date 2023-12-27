using System.Collections.Generic;
using System.Linq.Expressions;

namespace SampleWebAPI.DAL.Interface
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        TEntity GetEntity(TEntity entity);
        void Insert(TEntity entity); 
        void Update(TEntity entity);
        void Delete(TEntity entity);
        void Save();
        IQueryable<TEntity> Consult(Expression<Func<TEntity, Boolean>> filtro = null);


    }
}
