using Microsoft.EntityFrameworkCore;
using MyBlog.Core.Entities;
using MyBlog.Data.Context;
using MyBlog.Data.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Data.Repositories.Concretes
{
    public class WriteRepository<T> : IWriteRepository<T> where T : class, IBaseEntity, new()
    {

        private readonly BlogDbContext _context;
        public WriteRepository(BlogDbContext context)
        {
            _context = context;
        }
        private DbSet<T> Table { get => _context.Set<T>(); }

        public async Task AddAsync(T entity)
        {
            await Table.AddAsync(entity);
        }

        public async Task DeleteAsync(T entity)
        {
            await Task.Run(() => Table.Remove(entity));
        }

        public async Task<T> UpdateAsync(T entity)
        {
            await Task.Run(() =>  Table.Update(entity));
            return entity;
        }
    }
}
