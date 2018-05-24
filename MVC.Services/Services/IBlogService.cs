using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC.Services.DTO;
using MVC.DAL.Entities;

namespace MVC.Services.Services
{
    public interface IBlogService
    {
        bool AddBlog(BlogDTO blogDTO);
        bool UpdateBlog(BlogDTO blogDTO);
        bool RemoveBlog(int id);
        BlogDTO GetBlog(int id);
        List<BlogDTO> GetBlogList();
        bool IsBlogListEmpty();
        int BlogListCount();
        BlogDTO MapDataDTO(BlogEntity blogEntity);
        BlogEntity MapDataEntity(BlogDTO blogDTO);
    }
}
