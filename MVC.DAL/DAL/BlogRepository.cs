using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC.DAL.Entities;
using System.Data.SqlClient;
using System.Data;

namespace MVC.DAL.DAL
{
    public class BlogRepository : IBlogRepository
    {
        private BlogEntityList blogEntityList;

        private void CreateSampleData(int n)
        {
            for (int i = 1; i <= n; i++)
            {
                string title = "title" + i;
                string content = "content" + i;
                DateTime createdDate = DateTime.Now;
                string author = "author" + i;
                BlogEntity blogEntity = new BlogEntity(title: title,
                                                        content: content,
                                                        createdDate: createdDate,
                                                        author: author);
                blogEntityList.AddBlog(blogEntity);
            }
        }

        public BlogRepository()
        {
            blogEntityList = new BlogEntityList();
            CreateSampleData(5);
        }

        public bool AddBlog(BlogEntity blogEntity)
        {
            blogEntityList.AddBlog(blogEntity);
            return true;
        }

        public int BlogListCount()
        {
            int listCount = blogEntityList.Count();
            return listCount;
        }

        public BlogEntity GetBlog(int index)
        {
            BlogEntity blogEntity = blogEntityList.GetBlog(index);
            return blogEntity;
        }

        public BlogEntityList GetBlogList()
        {
            return blogEntityList;
        }

        public bool RemoveBlog(int index)
        {
            blogEntityList.RemoveBlog(index);
            return true;
        }

        public bool UpdateBlog(int index, BlogEntity blogEntity)
        {
            BlogEntity oldBlog = blogEntityList.GetBlog(index);
            oldBlog.Title = blogEntity.Title;
            oldBlog.Content = blogEntity.Content;
            oldBlog.Author = blogEntity.Author;
            return true;
        }
    }
}