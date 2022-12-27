using Microsoft.AspNetCore.Mvc;
using MyBlog.Data.Repositories.Abstractions;
using MyBlog.Entity.Entities;
using MyBlog.Services.RepoServices.Abstractions.Articles;
using MyBlog.Web.Models;
using System.Diagnostics;

namespace MyBlog.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IArticleReadService _articleRead;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IArticleReadService articleRead)
        {
            _logger = logger;
            _articleRead = articleRead;
        }

        public async Task<IActionResult> Index()
        {
          var result =   await _articleRead.GetAllArticleAsync();
            return View(result);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}