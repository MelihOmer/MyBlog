using AutoMapper;
using Microsoft.AspNetCore.Http;
using MyBlog.Data.UnitOfWorks;
using MyBlog.Entity.Entities;
using MyBlog.Entity.Models.Articles;
using MyBlog.Services.Extensions;
using MyBlog.Services.RepoServices.Abstractions.Articles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Services.RepoServices.Concretes.Articles
{
    public class ArticleWriteService : IArticleWriteService
    {
        private readonly IUnitOfWork UnitOfWork;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContext;
        private readonly ClaimsPrincipal _user;
        public ArticleWriteService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContext)
        {
            UnitOfWork = unitOfWork;
            _mapper = mapper;
            _httpContext = httpContext;
            _user = _httpContext.HttpContext.User;
        }



        public async Task CreateArticleAsync(ArticleAddVM articleAddVM)
        {
            var userId = _user.GetLoggedInUserId();
            var userEmail = _user.GetLoggedInEmail();

            var article = new Article(articleAddVM.Title,articleAddVM.Content,userId, userEmail, articleAddVM.CategoryId);


            await UnitOfWork.GetWriteRepository<Article>().AddAsync(article);
            await UnitOfWork.SaveAsync();
        }
        public async Task<string> UpdateArticleAsync(ArticleUpdateVM articleUpdateVM)
        {
            var userEmail = _user.GetLoggedInEmail();
            var article = await UnitOfWork.GetReadRepository<Article>().GetAsync(x => !x.IsDeleted && x.Id == articleUpdateVM.Id, x => x.Category);

            article.Title = articleUpdateVM.Title;
            article.Content = articleUpdateVM.Content;
            article.CategoryId = articleUpdateVM.CategoryId;
            article.ModifiedDate = DateTime.Now;
            article.ModifiedBy = userEmail;

            await UnitOfWork.GetWriteRepository<Article>().UpdateAsync(article);
            await UnitOfWork.SaveAsync();
            return article.Title;
        }
        public async Task<string> SafeDeleteArticleAsync(Guid articleId)
        {
            var userEmail = _user.GetLoggedInEmail();
            var article = await UnitOfWork.GetReadRepository<Article>().GetById(articleId);
            if (article != null)
            {

                article.IsDeleted = true;
                article.DeletedDated = DateTime.Now;
                article.DeletedBy = userEmail;
                await UnitOfWork.GetWriteRepository<Article>().UpdateAsync(article);
                await UnitOfWork.SaveAsync();
                
            }
            return article.Title;
        }
    }
}
