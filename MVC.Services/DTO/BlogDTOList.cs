using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Services.DTO
{
    public class BlogDTOList
    {
        private List<BlogDTO> list;

        public BlogDTOList()
        {
            list = new List<BlogDTO>();
        }

        public void AddBlog(BlogDTO blog)
        {
            list.Add(blog);
        }

        public int Count()
        {
            return list.Count;
        }

        public BlogDTO GetBlog(int index)
        {
            return list[index];
        }

        public void RemoveBlog(int index)
        {
            list.RemoveAt(index);
        }

        public void UpdateBlog(int index, BlogDTO blog)
        {
            list[index] = blog;
        }
    }
}