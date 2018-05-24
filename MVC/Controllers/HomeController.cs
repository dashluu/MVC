using MVC.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MVC.Services.Services;
using MVC.Services.DTO;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {
        private IBlogService blogService;

        public HomeController(IBlogService blogService)
        {
            this.blogService = blogService;
        }

        private Blog MapDataModel(BlogDTO blogDTO)
        {
            if (blogDTO == null)
            {
                return null;
            }
            Blog blog = new Blog()
            {
                BlogId = blogDTO.BlogId,
                Title = blogDTO.Title,
                Content = blogDTO.Content,
                CreatedDate = blogDTO.CreatedDate,
                Author = blogDTO.Author
            };
            return blog;
        }

        private BlogDTO MapDataDTO(Blog blog)
        {
            if (blog == null)
            {
                return null;
            }

            BlogDTO blogDTO = new BlogDTO()
            {
                BlogId = blog.BlogId,
                Title = blog.Title,
                Content = blog.Content,
                Author = blog.Author,
                CreatedDate = blog.CreatedDate
            };
            return blogDTO;
        }

        public ActionResult Index()
        {
            List<BlogDTO> blogDTOList = blogService.GetBlogList();
            List<Blog> blogList = new List<Blog>();
            foreach (BlogDTO blogDTO in blogDTOList)
            {
                Blog blog = MapDataModel(blogDTO);
                blogList.Add(blog);
            }
            return View(blogList);
        }

        [HttpPost]
        public ActionResult Index(int[] Data)
        {
            if (Data == null || Data.Length != 2)
            {
                return RedirectToAction("Index");
            }
            int id = Data[0];
            object values = new
            {
                Id = id
            };
            if (Data[1] == 0)
            {
                return RedirectToAction("EditBlog", "Home", values);
            }
            bool deleteSuccessful = blogService.RemoveBlog(id);
            if (!deleteSuccessful)
            {
                ModelState.AddModelError("", "Removing blog failed...");
            }
            return RedirectToAction("Index");
        }

        public ActionResult CreateBlog()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateBlog(Blog blog)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            BlogDTO blogDTO = MapDataDTO(blog);
            bool createSuccessful = blogService.AddBlog(blogDTO);
            if (!createSuccessful)
            {
                ModelState.AddModelError("", "Creating blog failed...");
                return View();
            }
            return RedirectToAction("Index");
        }

        public ActionResult EditBlog(int Id = -1)
        {
            BlogDTO blogDTO = blogService.GetBlog(Id);
            if (blogDTO == null)
            {
                return RedirectToAction("Index");
            }
            Blog blog = MapDataModel(blogDTO);
            return View(blog);
        }

        [HttpPost]
        public ActionResult EditBlog(Blog blog)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            BlogDTO blogDTO = MapDataDTO(blog);
            bool updateSuccessful = blogService.UpdateBlog(blogDTO);
            if (!updateSuccessful)
            {
                ModelState.AddModelError("", "Updating blog failed...");
                return View();
            }
            return RedirectToAction("Index");
        }

    }
}