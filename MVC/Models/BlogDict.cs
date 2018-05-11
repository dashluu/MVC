using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class BlogDict
    {
        public int Index { get; set; }
        public Blog Blog { get; set; }

        public BlogDict(Blog blog, int index)
        {
            Index = index;
            Blog = blog;
        }

        public BlogDict()
        {

        }
    }
}