using MyBlog.Entity.Models.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Services.RepoServices.Abstractions.Categories
{
    public interface ICategoryReadService
    {
        public Task<List<CategoryVM>> GetAllCategoriesNonDeleted();
    }
}
