using MyBlog.Entity.Models.Categories;

namespace MyBlog.Entity.Models.Articles
{
    public class ArticleVM
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public CategoryVM Category { get; set; }
        public int ViewCount { get; set; }
        public  string CreatedBy { get; set; }
        public  DateTime CreatedDate { get; set; }
        public bool IsDeleted { get; set; }

    }
}
