using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.IdentityModel.Tokens;
using MyBlog.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Data.Mappings
{
    public class ArticleMap : IEntityTypeConfiguration<Article>
    {
 
        public void Configure(EntityTypeBuilder<Article> builder)
        {
           

            builder.HasData(new Article
            {
                Id = Guid.Parse("E4705572-B7B0-4775-B02B-74F513D0CC89"),
                Title = "Asp.Net Core Deneme Makalesi 1",
                Content = "Lorem Ipsum, dizgi ve baskı endüstrisinde kullanılan mıgır metinlerdir. Lorem Ipsum, adı bilinmeyen bir matbaacının bir hurufat numune kitabı oluşturmak üzere bir yazı galerisini alarak karıştırdığı 1500'lerden beri endüstri standardı sahte metinler olarak kullanılmıştır.",
                ViewCount = 10,
                CategoryId = Guid.Parse("78F5F289-FFB9-4588-B3C9-888407CCF129"),
                CreatedBy = "Admin Test",
                CreatedDate = DateTime.Now,
                IsDeleted = false
            },new Article
            {
                Id = Guid.Parse("41646B7A-8C51-4A7A-86F7-C834A2FF5881"),
                Title = "Visual Studio Deneme Makalesi 1",
                Content = "Visual Studio Lorem Ipsum, dizgi ve baskı endüstrisinde kullanılan mıgır metinlerdir. Lorem Ipsum, adı bilinmeyen bir matbaacının bir hurufat numune kitabı oluşturmak üzere bir yazı galerisini alarak karıştırdığı 1500'lerden beri endüstri standardı sahte metinler olarak kullanılmıştır.",
                ViewCount = 10,
                CategoryId = Guid.Parse("C0F71C92-E8C9-4D75-B3EC-C00C9240FE8B"),
                CreatedBy = "Admin Test",
                CreatedDate = DateTime.Now,
                IsDeleted = false
            }
            );
        }
    }
}
