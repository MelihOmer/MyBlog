using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using MyBlog.Entity.Entities;
using MyBlog.Entity.Models.Articles;
using MyBlog.Services.Extensions;
using MyBlog.Services.RepoServices.Abstractions.Articles;
using MyBlog.Services.RepoServices.Abstractions.Categories;

namespace MyBlog.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ArticleController : Controller
    {
        private readonly IArticleReadService _articleRead;
        private readonly IArticleWriteService _articleWrite;
        private readonly ICategoryReadService _categoryRead;
        private readonly IMapper _mapper;
        private readonly IValidator<Article> _validator;
        public ArticleController(IArticleReadService articleRead, ICategoryReadService categoryRead, IArticleWriteService articleWrite,IMapper mapper,IValidator<Article> validator)
        {
            _articleRead = articleRead;
            _categoryRead = categoryRead;
            _articleWrite = articleWrite;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<IActionResult> Index()
        {
            var articles = await _articleRead.GetAllArticlesWithCategoryNonDeletedAsync();

            return View(articles);
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var categories = await _categoryRead.GetAllCategoriesNonDeleted();
            return View(new ArticleAddVM { Categories= categories });
        }
        [HttpPost]
        public async Task<IActionResult> Add(ArticleAddVM articleAddVM)
        {
            var map = _mapper.Map<Article>(articleAddVM);
            var result = await _validator.ValidateAsync(map);

            if (result.IsValid)
            {
                await _articleWrite.CreateArticleAsync(articleAddVM);
               return RedirectToAction("Index", "Article", new { Area = "Admin" });
            }
            else 
            {
                result.AddToModelState(this.ModelState);
                var categories = await _categoryRead.GetAllCategoriesNonDeleted();
                return View(new ArticleAddVM { Categories = categories });
            }


            
        }
        [HttpGet]
        public async Task<IActionResult> Update(Guid ArticleId)
        {
            var article = await _articleRead.GetAllArticleWithCategoryNonDeletedAsync(ArticleId);
            var categories = await _categoryRead.GetAllCategoriesNonDeleted();

            var articleUpdateVm = _mapper.Map<ArticleUpdateVM>(article);
            articleUpdateVm.Categories = categories;

            return View(articleUpdateVm);
        }
        [HttpPost]
        public async Task<IActionResult> Update(ArticleUpdateVM articleUpdateVM)
        {

            var map = _mapper.Map<Article>(articleUpdateVM);
            var result = await _validator.ValidateAsync(map);


            if (result.IsValid)
            {
                await _articleWrite.UpdateArticleAsync(articleUpdateVM);
                return RedirectToAction("Index", "Article", new { Area = "Admin" });

            }
            else
            {
                result.AddToModelState(this.ModelState);
                var categories = await _categoryRead.GetAllCategoriesNonDeleted();
                articleUpdateVM.Categories = categories;
                return View(new ArticleUpdateVM { Categories = categories });
            }

            

        }
        [HttpGet]
        public async Task<IActionResult> Delete(Guid articleId)
        {
            await _articleWrite.SafeDeleteArticleAsync(articleId);
            return RedirectToAction("Index", "Article", new { Area = "Admin" });
        }
    }
}
