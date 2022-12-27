using MyBlog.Data.Context;
using MyBlog.Data.Repositories.Abstractions;
using MyBlog.Data.Repositories.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Data.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BlogDbContext context;

        public UnitOfWork(BlogDbContext context)
        {
            this.context = context;
        }
        public async ValueTask DisposeAsync()
        {
           await context.DisposeAsync();
        }

        public Task<int> SaveAsync()
        {
            return context.SaveChangesAsync();
        }

        IReadRepository<T> IUnitOfWork.GetReadRepository<T>()
        {
            return new ReadRepository<T>(context);
        }

        IWriteRepository<T> IUnitOfWork.GetWriteRepository<T>()
        {
            return new WriteRepository<T>(context);
        }
    }
}
