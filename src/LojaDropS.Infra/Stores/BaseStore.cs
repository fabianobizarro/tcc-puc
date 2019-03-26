using LojaDropS.Infra.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LojaDropS.Infra.Stores
{
    public class BaseStore<T> : IBaseStore<T> where T : class
    {
        private readonly IAppDbContext _context;

        public BaseStore(IAppDbContext db)
        {
            _context = db;
        }

        public virtual async Task<T> AddAsync(T entity)
        {
            var result = await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public virtual async Task DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public virtual async Task<T> UpdateAsync(T entity)
        {
            var result =  _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
            return result.Entity;
        }
    }
}
