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
        public async Task<TEntity> Insert(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            await _context.SaveChangesAsync();

            return entity; 
        }
        public async Task<bool> Update(TEntity entity)
        {
            try
            {
                _context.Update(entity);
                await _context.SaveChangesAsync();
                return true; 
            }
            catch (Exception)
            {

                return false; 
            }


        }
        public async Task<TEntity> GetEntity(TEntity entity)
        {
            TEntity entityByID= await _context.Set<TEntity>().Where(entity => entity == entity).FirstOrDefaultAsync();
            return entityByID; 
        }
        public async Task<bool> Delete(TEntity entity)
        {

            try
            {
                _context.Remove(entity);
                await _context.SaveChangesAsync();
                return true; 
            }
            catch 
            {
                return false; 
            }

        }

        public async Task<IQueryable<TEntity>> Consult(Expression<Func<TEntity, bool>> filter = null)
        {
            IQueryable<TEntity> queryEntidad = filter == null ? _context.Set<TEntity>() : _context.Set<TEntity>().Where(filter);
            return queryEntidad;
        }




    }
}
