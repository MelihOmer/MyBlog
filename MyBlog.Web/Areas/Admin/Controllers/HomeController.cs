using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyBlog.Services.RepoServices.Abstractions.Articles;

namespace MyBlog.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class HomeController : Controller
    {
        
        private readonly IArticleReadService _articleRead;
        
        public HomeController(IArticleReadService articleRead)
        {
            _articleRead = articleRead;
        }

        public async Task<IActionResult> Index()
        {
           var result =  await _articleRead.GetAllArticlesWithCategoryNonDeletedAsync();

            return View(result);
        }
    }
}
