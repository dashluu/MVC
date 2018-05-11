using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC.Models;

namespace Services
{
    public class BlogService : IBlogService
    {
        public bool AddBlog(Blog blog)
        {
            blog.CreatedDate = DateTime.Now;
            // Call DAL
            return true;
        }

        public bool DeleteBlog(int index)
        {
            throw new NotImplementedException();
        }

        public bool EditBlog(BlogDict blogDict)
        {
            throw new NotImplementedException();
        }
    }
}
