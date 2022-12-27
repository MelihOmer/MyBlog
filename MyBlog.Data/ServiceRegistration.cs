using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyBlog.Data.Context;
using MyBlog.Data.Repositories.Abstractions;
using MyBlog.Data.Repositories.Concretes;
using MyBlog.Data.UnitOfWorks;

namespace MyBlog.Data
{
    public static class ServiceRegistration
    {
        public static void AddDataServices(this IServiceCollection services, IConfigurationRoot builder)
        {
            services.AddDbContext<BlogDbContext>(opt => opt.UseSqlServer(builder.GetConnectionString("Default")));
            services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));
            services.AddScoped(typeof(IWriteRepository<>), typeof(WriteRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

        }


    }
}
