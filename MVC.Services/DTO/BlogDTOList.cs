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

        public void AddBlogDTO(BlogDTO blogDTO)
        {
            list.Add(blogDTO);
        }

        public int Count()
        {
            return list.Count;
        }

        public BlogDTO GetBlogDTO(int index)
        {
            return list[index];
        }

        public void RemoveBlogDTO(int index)
        {
            list.RemoveAt(index);
        }

        public void UpdateBlogDTO(int index, BlogDTO blogDTO)
        {
            list[index] = blogDTO;
        }
    }
}