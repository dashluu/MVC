using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.DAL.Entities
{
    public class BlogEntityList
    {
        private List<BlogEntity> list;

        public BlogEntityList()
        {
            list = new List<BlogEntity>();
        }

        public void AddBlog(BlogEntity blog)
        {
            list.Add(blog);
        }

        public int Count()
        {
            return list.Count;
        }

        public List<BlogEntity> GetBlogList()
        {
            return list;
        }

        public BlogEntity GetBlog(int index)
        {
            return list[index];
        }

        public void RemoveBlog(int index)
        {
            list.RemoveAt(index);
        }

        public void UpdateBlog(int index, BlogEntity blog)
        {
            list[index] = blog;
        }
    }
}