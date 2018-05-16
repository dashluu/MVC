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
        public bool AddBlog(BlogEntity blogEntity)
        {
            try
            {
                using (var blogContext = new BlogContext())
                {
                    blogContext.Blogs.Add(blogEntity);
                    blogContext.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public int BlogListCount()
        {
            try
            {
                int listCount;
                using (var blogContext = new BlogContext())
                {
                    listCount = blogContext.Blogs.Count();
                }
                return listCount;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public BlogEntity GetBlog(int id)
        {
            try
            {
                BlogEntity blogEntity;
                using (var blogContext = new BlogContext())
                {
                    blogEntity = blogContext.Blogs.Where(x => x.BlogId == id).FirstOrDefault();
                }
                return blogEntity;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public BlogEntityList GetBlogList()
        {
            try
            {
                BlogEntityList blogEntityList = new BlogEntityList();
                using (var blogContext = new BlogContext())
                {
                    var blogDBSet = blogContext.Blogs;
                    foreach (BlogEntity blogEntity in blogDBSet)
                    {
                        blogEntityList.AddBlogEntity(blogEntity);
                    }
                }
                return blogEntityList;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool RemoveBlog(int id)
        {
            try
            {
                using (var blogContext = new BlogContext())
                {
                    BlogEntity blogEntity = blogContext.Blogs.Where(x => x.BlogId == id).FirstOrDefault();
                    blogContext.Blogs.Remove(blogEntity);
                    blogContext.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateBlog(BlogEntity blogEntity)
        {
            try
            {
                using (var blogContext = new BlogContext())
                {
                    BlogEntity oldBlog = blogContext.Blogs.Where(x => x.BlogId == blogEntity.BlogId).FirstOrDefault();
                    oldBlog.Title = blogEntity.Title;
                    oldBlog.Content = blogEntity.Content;
                    oldBlog.Author = blogEntity.Author;
                    blogContext.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}