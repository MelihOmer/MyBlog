using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using MyBlog.Services.FluentValidationsService;
using MyBlog.Services.RepoServices.Abstractions.Articles;
using MyBlog.Services.RepoServices.Abstractions.Categories;
using MyBlog.Services.RepoServices.Concretes.Articles;
using MyBlog.Services.RepoServices.Concretes.Categories;
using System.Globalization;
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

            services.AddControllersWithViews().AddFluentValidation(opt =>
            {
                opt.RegisterValidatorsFromAssemblyContaining<ArticleValidations>();
                opt.DisableDataAnnotationsValidation = true;
                opt.ValidatorOptions.LanguageManager.Culture = new CultureInfo("tr");
            });
            services.AddSingleton<IHttpContextAccessor,HttpContextAccessor>();

        }
    }
}
