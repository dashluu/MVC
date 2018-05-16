using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC.DAL.DAL;
using MVC.DAL.Entities;
using MVC.Services.DTO;

namespace MVC.Services.Services
{
    public class BlogService : IBlogService
    {
        private IBlogRepository blogRepository;

        public BlogService(IBlogRepository blogRepository)
        {
            this.blogRepository = blogRepository;
        }

        public bool AddBlog(BlogDTO blogDTO)
        {
            if (blogDTO == null)
            {
                return false;
            }
            blogDTO.CreatedDate = DateTime.Now;
            BlogEntity blogEntity = MapDataEntity(blogDTO);
            bool addSuccessful = blogRepository.AddBlog(blogEntity);
            return addSuccessful;
        }

        public int BlogListCount()
        {
            return blogRepository.BlogListCount();
        }

        public BlogDTO GetBlog(int id)
        {
            if (id < 0)
            {
                return null;
            }
            BlogEntity blogEntity = blogRepository.GetBlog(id);
            BlogDTO blogDTO = MapDataDTO(blogEntity);
            return blogDTO;
        }

        public BlogDTOList GetBlogList()
        {
            BlogEntityList blogEntityList = blogRepository.GetBlogList();
            BlogDTOList blogDTOList = new BlogDTOList();
            int blogListCount = blogEntityList.Count();
            for (int i = 0; i < blogListCount; i++)
            {
                BlogEntity blogEntity = blogEntityList.GetBlogEntity(i);
                BlogDTO blogDTO = MapDataDTO(blogEntity);
                blogDTOList.AddBlogDTO(blogDTO);
            }
            return blogDTOList;
        }

        public bool IsBlogListEmpty()
        {
            int blogListCount = BlogListCount();
            bool isEmpty = (blogListCount == 0);
            return isEmpty;
        }

        public BlogDTO MapDataDTO(BlogEntity blogEntity)
        {
            if (blogEntity == null)
            {
                return null;
            }
            BlogDTO blogDTO = new BlogDTO(blogId: blogEntity.BlogId,
                                        title: blogEntity.Title,
                                        content: blogEntity.Content,
                                        createdDate: blogEntity.CreatedDate,
                                        author: blogEntity.Author);
            return blogDTO;
        }

        public BlogEntity MapDataEntity(BlogDTO blogDTO)
        {
            if (blogDTO == null)
            {
                return null;
            }
            BlogEntity blogEntity = new BlogEntity(blogId: blogDTO.BlogId,
                                    title: blogDTO.Title,
                                    content: blogDTO.Content,
                                    createdDate: blogDTO.CreatedDate,
                                    author: blogDTO.Author);
            return blogEntity;
        }

        public bool RemoveBlog(int id)
        {
            if (id < 0)
            {
                return false;
            }
            bool removeSuccessful = blogRepository.RemoveBlog(id);
            return removeSuccessful;
        }

        public bool UpdateBlog(BlogDTO blogDTO)
        {
            if (blogDTO == null || blogDTO.BlogId < 0)
            {
                return false;
            }
            BlogEntity blogEntity = MapDataEntity(blogDTO);
            bool updateSuccessful = blogRepository.UpdateBlog(blogEntity);
            return updateSuccessful;
        }
    }
}
