using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.DAL.Entities
{
    public class BlogEntity
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime CreatedDate { get; set; }

        public string Author { get; set; }

        public BlogEntity(string title, string content, DateTime createdDate, string author)
        {
            Title = title;
            Content = content;
            CreatedDate = createdDate;
            Author = author;
        }
    }
}
