using MyBlog.Core.Entities;
using MyBlog.Data.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Data.UnitOfWorks
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IWriteRepository<T> GetWriteRepository<T>() where T :class ,IBaseEntity, new();
        IReadRepository<T> GetReadRepository<T>() where T :class ,IBaseEntity, new();
        Task<int> SaveAsync();
    }
}
