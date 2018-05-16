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

        public void AddBlogEntity(BlogEntity blogEntity)
        {
            list.Add(blogEntity);
        }

        public int Count()
        {
            return list.Count;
        }

        public BlogEntity GetBlogEntity(int index)
        {
            return list[index];
        }

        public void RemoveBlogEntity(int index)
        {
            list.RemoveAt(index);
        }

        public void UpdateBlogEntity(int index, BlogEntity blogEntity)
        {
            list[index] = blogEntity;
        }
    }
}