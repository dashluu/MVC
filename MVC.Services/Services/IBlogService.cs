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
        bool UpdateBlog(int index, BlogDTO blogDTO);
        bool RemoveBlog(int index);
        BlogDTO GetBlog(int index);
        BlogDTOList GetBlogList();
        bool IsBlogListEmpty();
        int BlogListCount();
        BlogDTO MapDataDTO(BlogEntity blogEntity);
        BlogEntity MapDataEntity(BlogDTO blogDTO);
    }
}
