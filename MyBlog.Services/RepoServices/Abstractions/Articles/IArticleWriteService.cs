using MyBlog.Entity.Models.Articles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Services.RepoServices.Abstractions.Articles
{
    public interface IArticleWriteService
    {
        Task CreateArticleAsync(ArticleAddVM articleAddVM);
        Task<string> UpdateArticleAsync(ArticleUpdateVM articleUpdateVM);
        Task<string> SafeDeleteArticleAsync(Guid articleId);
    }
}
