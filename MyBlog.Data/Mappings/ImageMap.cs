using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyBlog.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Data.Mappings
{
    public class ImageMap : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.HasData(new Image
            {
                Id = Guid.Parse("B61018F1-65C1-4AB1-98AA-BCE223156590"),
                ArticleId = Guid.Parse("E4705572-B7B0-4775-B02B-74F513D0CC89"),
                CreatedBy = "Admin Test",
                CreatedDate = DateTime.Now,
                FileName = "images/TestImage",
                FileType = "JPEG",
                IsDeleted = false

            },
            new Image
            {
                Id = Guid.Parse("58F06691-F7BA-4794-9DA4-BB4895BF8426"),
                ArticleId = Guid.Parse("41646B7A-8C51-4A7A-86F7-C834A2FF5881"),
                CreatedBy = "Admin Test",
                CreatedDate = DateTime.Now,
                FileName = "images/vs2022images",
                FileType = "JPEG",
                IsDeleted = false
            });
        }
    }
}
