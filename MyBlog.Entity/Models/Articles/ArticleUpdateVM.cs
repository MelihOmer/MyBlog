using MyBlog.Entity.Models.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Entity.Models.Articles
{
    public class ArticleUpdateVM
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public Guid CategoryId { get; set; }
        public IList<CategoryVM> Categories { get; set; }
    }
}
