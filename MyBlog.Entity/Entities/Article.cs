using MyBlog.Core.Entities;

namespace MyBlog.Entity.Entities
{
    public class Article : BaseEntity
    {
        public Article()
        {

        }
        public Article(string title, string content, Guid userId, Guid categoryId)
        {
            Title = title;
            Content = content;
            UserId = userId;
            CategoryId = categoryId;
        }

        public string Title { get; set; }
        public string Content { get; set; }
        public int ViewCount { get; set; } = 0;

        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<Image> Images { get; set; }

        public Guid UserId { get; set; }
        public AppUser User { get; set; }

    }
}
