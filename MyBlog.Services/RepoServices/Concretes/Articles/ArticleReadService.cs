using AutoMapper;
using MyBlog.Data.UnitOfWorks;
using MyBlog.Entity.Entities;
using MyBlog.Entity.Models.Articles;
using MyBlog.Services.RepoServices.Abstractions.Articles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Services.RepoServices.Concretes.Articles
{
    public class ArticleReadService : IArticleReadService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ArticleReadService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<List<ArticleVM>> GetAllArticlesWithCategoryNonDeletedAsync()
        {
            
          var articles  =   await _unitOfWork.GetReadRepository<Article>().GetAllAsync(x => !x.IsDeleted,y => y.Category);
            return _mapper.Map<List<ArticleVM>>(articles);
        }
        public async Task<ArticleVM> GetAllArticleWithCategoryNonDeletedAsync(Guid ArticleId)
        {
            var articles = await _unitOfWork.GetReadRepository<Article>().GetAsync(x => !x.IsDeleted && x.Id == ArticleId, y => y.Category);
            return _mapper.Map<ArticleVM>(articles);
        }
    }
}
