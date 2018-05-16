using MVC.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.DAL.DAL
{
    public interface IBlogRepository
    {
        bool AddBlog(BlogEntity blogEntity);
        bool UpdateBlog(BlogEntity blogEntity);
        bool RemoveBlog(int id);
        BlogEntity GetBlog(int id);
        BlogEntityList GetBlogList();
        int BlogListCount();
    }
}
