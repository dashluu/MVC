using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Services.DTO
{
    public class BlogDTO
    {
        public int BlogId { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime CreatedDate { get; set; }

        public string Author { get; set; }

        public BlogDTO(int blogId, string title, string content, DateTime createdDate, string author)
        {
            BlogId = blogId;
            Title = title;
            Content = content;
            CreatedDate = createdDate;
            Author = author;
        }
    }
}
