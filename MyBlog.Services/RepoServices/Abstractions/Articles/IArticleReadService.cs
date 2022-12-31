using MyBlog.Entity.Entities;
using MyBlog.Entity.Models.Articles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Services.RepoServices.Abstractions.Articles
{
    public interface IArticleReadService
    {      
        Task<List<ArticleVM>> GetAllArticlesWithCategoryNonDeletedAsync();





    }
}
