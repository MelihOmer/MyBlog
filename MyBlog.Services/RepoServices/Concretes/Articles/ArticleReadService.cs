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
        public async Task<List<ArticleVM>> GetAllArticleAsync()
        {
            
          var articles  =   await _unitOfWork.GetReadRepository<Article>().GetAllAsync();
            return _mapper.Map<List<ArticleVM>>(articles);
        }
    }
}
