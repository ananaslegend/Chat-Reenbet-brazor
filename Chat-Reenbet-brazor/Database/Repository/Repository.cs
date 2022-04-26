using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
//using System.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace Chat_Reenbet_brazor.DB
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext _context;
        public Repository(DbContext context)
        {
            _context = context;
        }
        public void Add(TEntity item)
        {
            _context.Set<TEntity>().Add(item);
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predecate)
        {
            return _context.Set<TEntity>().Where(predecate);
        }

        public TEntity Get(int id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }

        public void Remove(TEntity item)
        {
            _context.Set<TEntity>().Remove(item);
        }
    }
}
