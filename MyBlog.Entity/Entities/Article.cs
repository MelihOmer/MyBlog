using MyBlog.Core.Entities;

namespace MyBlog.Entity.Entities
{
    public class Article : BaseEntity
    {

        public string Title { get; set; }
        public string Content { get; set; }
        public int ViewCount { get; set; }

        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<Image> Images { get; set; }
 
    }
}
