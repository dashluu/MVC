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
        private IBaseRepository<BlogEntity, int> blogRepository;

        public BlogService(IBaseRepository<BlogEntity, int> blogRepository)
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
            bool addSuccessful = blogRepository.Add(blogEntity);
            return addSuccessful;
        }

        public int BlogListCount()
        {
            return blogRepository.Count();
        }

        public BlogDTO GetBlog(int id)
        {
            if (id < 0)
            {
                return null;
            }
            BlogEntity blogEntity = blogRepository.Get(id);
            BlogDTO blogDTO = MapDataDTO(blogEntity);
            return blogDTO;
        }

        public List<BlogDTO> GetBlogList()
        {
            List<BlogEntity> blogEntityList = blogRepository.GetList();
            List<BlogDTO> blogDTOList = new List<BlogDTO>();
            foreach(BlogEntity blogEntity in blogEntityList)
            {
                BlogDTO blogDTO = MapDataDTO(blogEntity);
                blogDTOList.Add(blogDTO);
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
            BlogDTO blogDTO = new BlogDTO()
            {
                BlogId = blogEntity.BlogId,
                Title = blogEntity.Title,
                Content = blogEntity.Content,
                Author = blogEntity.Author,
                CreatedDate = blogEntity.CreatedDate
            };
            return blogDTO;
        }

        public BlogEntity MapDataEntity(BlogDTO blogDTO)
        {
            if (blogDTO == null)
            {
                return null;
            }
            BlogEntity blogEntity = new BlogEntity()
            {
                BlogId = blogDTO.BlogId,
                Title = blogDTO.Title,
                Content = blogDTO.Content,
                Author = blogDTO.Author,
                CreatedDate = blogDTO.CreatedDate
            };
            return blogEntity;
        }

        public bool RemoveBlog(int id)
        {
            if (id < 0)
            {
                return false;
            }
            BlogEntity blogEntity = blogRepository.Get(id);
            if (blogEntity == null)
            {
                return false;
            }
            bool removeSuccessful = blogRepository.Remove(blogEntity);
            return removeSuccessful;
        }

        public bool UpdateBlog(BlogDTO blogDTO)
        {
            if (blogDTO == null || blogDTO.BlogId < 0)
            {
                return false;
            }
            BlogEntity blogEntity = MapDataEntity(blogDTO);
            bool updateSuccessful = blogRepository.Update(blogEntity);
            return updateSuccessful;
        }
    }
}
