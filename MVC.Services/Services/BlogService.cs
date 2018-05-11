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

        public BlogService()
        {
            blogRepository = new BlogRepository();
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
            int listCount = blogRepository.BlogListCount();
            return listCount;
        }

        public BlogDTO GetBlog(int index)
        {
            if (index < 0 || index >= BlogListCount())
            {
                return null;
            }
            BlogEntity blogEntity = blogRepository.GetBlog(index);
            BlogDTO blogDTO = MapDataDTO(blogEntity);
            return blogDTO;
        }

        public BlogDTOList GetBlogList()
        {
            BlogEntityList blogEntityList = blogRepository.GetBlogList();
            BlogDTOList blogDTOList = new BlogDTOList();
            int blogEntityCount = blogEntityList.Count();
            for (int i = 0; i < blogEntityCount; i++)
            {
                BlogEntity blogEntity = blogEntityList.GetBlog(i);
                BlogDTO blogDTO = MapDataDTO(blogEntity);
                blogDTOList.AddBlog(blogDTO);
            }
            return blogDTOList;
        }

        public bool IsBlogListEmpty()
        {
            int listCount = BlogListCount();
            bool isEmpty = (listCount == 0);
            return isEmpty;
        }

        public BlogDTO MapDataDTO(BlogEntity blogEntity)
        {
            BlogDTO blogDTO = new BlogDTO(title: blogEntity.Title,
                                        content: blogEntity.Content,
                                        createdDate: blogEntity.CreatedDate,
                                        author: blogEntity.Author);
            return blogDTO;
        }

        public BlogEntity MapDataEntity(BlogDTO blogDTO)
        {
            BlogEntity blogEntity = new BlogEntity(title: blogDTO.Title,
                                    content: blogDTO.Content,
                                    createdDate: blogDTO.CreatedDate,
                                    author: blogDTO.Author);
            return blogEntity;
        }

        public bool RemoveBlog(int index)
        {
            if (index < 0 || index >= BlogListCount())
            {
                return false;
            }
            bool removeSuccessful = blogRepository.RemoveBlog(index);
            return removeSuccessful;
        }

        public bool UpdateBlog(int index, BlogDTO blogDTO)
        {
            if (index < 0 || index >= BlogListCount() || blogDTO == null)
            {
                return false;
            }
            BlogEntity blogEntity = MapDataEntity(blogDTO);
            bool updateSuccessful = blogRepository.UpdateBlog(index, blogEntity);
            return updateSuccessful;
        }
    }
}
