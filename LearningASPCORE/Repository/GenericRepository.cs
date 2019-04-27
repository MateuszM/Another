using LearningASPCORE.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LearningASPCORE.Repository
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        
            private ApplicationDbContext _context = null;
            DbSet<T> _objectSet;
            public GenericRepository(ApplicationDbContext _db)
            {
               _context = _db;
                _objectSet = _context.Set<T>();
            }
            public void Add(T entity)
            {
                _objectSet.Add(entity);
            }
            public void Delete(T entity)
            {
                _objectSet.Remove(entity);
            }
              public async Task<IEnumerable<T>> GetAllAsync()
              {
                   return await _objectSet.ToListAsync<T>();
              }
        public IEnumerable<T> GetAll()
        {
            return _objectSet.ToList<T>();
        }
         
            public T GetDetail(Expression<Func<T, bool>> predicate)
            {
                return _objectSet.First(predicate);
            }

            public IEnumerable<T> GetOverview(Expression<Func<T, bool>> predicate = null)
            {
                if (predicate != null)
                    return _objectSet.Where(predicate);
                return _objectSet.AsEnumerable();
            }
        
    }
}
