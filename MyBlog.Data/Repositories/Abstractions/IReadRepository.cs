using MyBlog.Core.Entities;
using MyBlog.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Data.Repositories.Abstractions
{
    public interface IReadRepository<T> where T:class,IBaseEntity,new()
    {
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter = null, params Expression<Func<T, object>>[] includeProperties);
        Task<T> GetAsync(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] includeProperties);
        Task<T> GetById(Guid id);
        Task<bool> AnyAsync(Expression<Func<T, bool>> filter);
        Task<int> Count(Expression<Func<T, bool>> filter = null);
    }
}
