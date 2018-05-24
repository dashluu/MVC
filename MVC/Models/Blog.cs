using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class Blog
    {
        public int BlogId { get; set; }

        [Required(ErrorMessage = "Blog's title is required.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Blog's content is required.")]
        public string Content { get; set; }

        public DateTime CreatedDate { get; set; }

        [Required(ErrorMessage = "Blog's author is required.")]
        public string Author { get; set; }

        public Blog()
        {

        }
    }
}