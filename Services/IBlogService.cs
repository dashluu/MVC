using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC.Models;

namespace Services
{
    interface IBlogService
    {
        bool AddBlog(Blog blog);
        bool EditBlog(BlogDict blogDict);
        bool DeleteBlog(int index);
    }
}
