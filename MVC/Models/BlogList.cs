using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class BlogList
    {
        private List<Blog> list;

        public BlogList()
        {
            list = new List<Blog>();
        }

        public void AddBlog(Blog blog)
        {
            list.Add(blog);
        }

        public int Count()
        {
            return list.Count;
        }

        public Blog GetBlog(int index)
        {
            return list[index];
        }

        public void RemoveBlog(int index)
        {
            list.RemoveAt(index);
        }

        public void UpdateBlog(int index, Blog blog)
        {
            list[index] = blog;
        }
    }
}