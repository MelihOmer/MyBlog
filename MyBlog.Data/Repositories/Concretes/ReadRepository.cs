using Microsoft.EntityFrameworkCore;
using MyBlog.Core.Entities;
using MyBlog.Data.Context;
using MyBlog.Data.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Data.Repositories.Concretes
{
    public class ReadRepository<T> : IReadRepository<T> where T : class,IBaseEntity,new()
    {
        private readonly BlogDbContext _context;
        public ReadRepository(BlogDbContext context)
        {
            _context = context;
        }
        private DbSet<T> Table { get => _context.Set<T>();}

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> filter)
        {
            return await Table.AnyAsync(filter);
        }

        public async Task<int> Count(Expression<Func<T, bool>> filter = null)
        {
            return await Table.CountAsync(filter);
        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter = null,params Expression<Func<T, bool>>[] includeProperties)
        {
            IQueryable<T> query = Table;
            if (filter != null)
                query = query.Where(filter);


            if (includeProperties.Any())
                foreach (var item in includeProperties)
                    query = query.Include(item);

            return await query.ToListAsync();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> filter , params Expression<Func<T, bool>>[] includeProperties)
        {
            IQueryable<T> query = Table;
            query = query.Where(filter);

            if (includeProperties.Any())
                foreach (var item in includeProperties)
                    query = query.Include(item);
            return await query.SingleAsync();
        }

        public async Task<T> GetById(Guid id)
        {
            return await Table.FindAsync(id);
        }
    }
}
