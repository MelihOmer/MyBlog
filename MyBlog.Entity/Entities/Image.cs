using MyBlog.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Entity.Entities
{
    public class Image : BaseEntity
    {

        public Image()
        {

        }
        public Image(string fileName, string fileType)
        {
            FileName = fileName;
            FileType = fileType;
        }
        public string FileName { get; set; }
        public string FileType { get; set; }
        public Guid ArticleId { get; set; }
        public Article Article { get; set; }
        public Guid? UserId { get; set; }
        public AppUser User { get; set; }
    }
}
