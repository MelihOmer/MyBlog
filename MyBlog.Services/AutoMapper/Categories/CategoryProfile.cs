using AutoMapper;
using MyBlog.Entity.Entities;
using MyBlog.Entity.Models.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Services.AutoMapper.Categories
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<CategoryVM, Category>().ReverseMap();
        }
    }
}
