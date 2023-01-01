using AutoMapper;
using MyBlog.Data.UnitOfWorks;
using MyBlog.Entity.Entities;
using MyBlog.Entity.Models.Articles;
using MyBlog.Services.RepoServices.Abstractions.Articles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Services.RepoServices.Concretes.Articles
{
    public class ArticleWriteService : IArticleWriteService
    {
        private readonly IUnitOfWork UnitOfWork;
        private readonly IMapper _mapper;
        public ArticleWriteService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            UnitOfWork = unitOfWork;
            _mapper = mapper;
        }



        public async Task CreateArticleAsync(ArticleAddVM articleAddVM)
        {
            var userId = Guid.Parse("B0F21285-8B81-4C46-BC74-3E1DB74290FB");
            var article = new Article
            {
                Title = articleAddVM.Title,
                Content = articleAddVM.Content,
                CategoryId = articleAddVM.CategoryId,
                UserId = userId
            };
            await UnitOfWork.GetWriteRepository<Article>().AddAsync(article);
            await UnitOfWork.SaveAsync();
        }
        public async Task UpdateArticleAsync(ArticleUpdateVM articleUpdateVM)
        {
            var article = await UnitOfWork.GetReadRepository<Article>().GetAsync(x => !x.IsDeleted && x.Id == articleUpdateVM.Id, x => x.Category);

            article.Title = articleUpdateVM.Title;
            article.Content = articleUpdateVM.Content;
            article.CategoryId = articleUpdateVM.CategoryId;

            await UnitOfWork.GetWriteRepository<Article>().UpdateAsync(article);
            await UnitOfWork.SaveAsync();
        }
        public async Task SafeDeleteArticleAsync(Guid articleId)
        {
            var article = await UnitOfWork.GetReadRepository<Article>().GetById(articleId);
            if (article != null)
            {

                article.IsDeleted = true;
                article.DeletedDated = DateTime.Now;
                await UnitOfWork.GetWriteRepository<Article>().UpdateAsync(article);
                await UnitOfWork.SaveAsync();
            }
        }
    }
}
