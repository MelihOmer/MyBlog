using Microsoft.AspNetCore.Mvc;
using MyBlog.Services.RepoServices.Abstractions.Articles;

namespace MyBlog.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ArticleController : Controller
    {
        private readonly IArticleReadService _articleRead;

        public ArticleController(IArticleReadService articleRead)
        {
            _articleRead = articleRead;
        }

        public async Task<IActionResult> Index()
        {
            var articles = await _articleRead.GetAllArticlesWithCategoryNonDeletedAsync();

            return View(articles);
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return View();
        }
    }
}
