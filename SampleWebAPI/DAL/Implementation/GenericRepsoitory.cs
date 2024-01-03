using Microsoft.EntityFrameworkCore;
using SampleWebAPI.DAL.Context;
using SampleWebAPI.DAL.Interface;
using SampleWebAPI.Models;
using System.Linq.Expressions;

namespace SampleWebAPI.DAL.Implementation
{
    public class GenericRepsoitory<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private StudentContext _context = null;
        private DbSet<TEntity> table = null;

        public GenericRepsoitory(StudentContext dbContext)
        {
            this._context = dbContext; 
        }
        public void Insert(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            _context.SaveChanges(); 
        }
        public void Update(TEntity entity)
        {
            _context.Update(entity); 
            _context.SaveChanges();
        }
        public TEntity GetEntity(TEntity entity)
        {
            TEntity entityByID= _context.Set<TEntity>().Where(entity => entity == entity).FirstOrDefault();
            return entityByID; 
        }
        public void Delete(TEntity entity)
        {
            _context.Remove(entity);
            _context.SaveChanges();
        }
        public void Save()
        {
            throw new NotImplementedException();
        }
        public IQueryable<TEntity> Consult(Expression<Func<TEntity, bool>> filter = null)
        {
            IQueryable<TEntity> queryEntidad = filter == null ? _context.Set<TEntity>() : _context.Set<TEntity>().Where(filter);
            return queryEntidad;
        }




    }
}
