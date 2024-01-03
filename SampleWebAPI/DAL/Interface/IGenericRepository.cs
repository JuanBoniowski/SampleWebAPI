using System.Collections.Generic;
using System.Linq.Expressions;

namespace SampleWebAPI.DAL.Interface
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetEntity(TEntity entity);
        Task<TEntity> Insert(TEntity entity); 
        Task<bool> Update(TEntity entity);
        Task<bool> Delete(TEntity entity);        
        Task<IQueryable<TEntity>> Consult(Expression<Func<TEntity, Boolean>> filtro = null);


    }
}
