using AutoMapper;
using MyBlog.Entity.Entities;
using MyBlog.Entity.Models.Articles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Services.AutoMapper.Articles
{
    public class ArticleProfile : Profile
    {
        public ArticleProfile()
        {
            CreateMap<ArticleVM, Article>().ReverseMap();
        }
    }
}
