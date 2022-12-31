using Microsoft.Extensions.DependencyInjection;
using MyBlog.Services.RepoServices.Abstractions.Articles;
using MyBlog.Services.RepoServices.Abstractions.Categories;
using MyBlog.Services.RepoServices.Concretes.Articles;
using MyBlog.Services.RepoServices.Concretes.Categories;
using System.Reflection;

namespace MyBlog.Services
{
    public static class ServiceRegistration
    {
        public static void AddServicesLayer(this IServiceCollection services)
        {
            
            services.AddScoped<IArticleReadService, ArticleReadService>();
            services.AddScoped<IArticleWriteService, ArticleWriteService>();

            services.AddScoped<ICategoryReadService, CategoryReadService>();

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }
    }
}
