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
            Blog blog = new Blog(title: blogDTO.Title,
                                        content: blogDTO.Content,
                                        createdDate: blogDTO.CreatedDate,
                                        author: blogDTO.Author);
            return blog;
        }

        private BlogDTO MapDataDTO(Blog blog)
        {
            BlogDTO blogDTO = new BlogDTO(title: blog.Title,
                                        content: blog.Content,
                                        createdDate: blog.CreatedDate,
                                        author: blog.Author);
            return blogDTO;
        }

        private BlogList GetBlogListHelper()
        {
            BlogDTOList blogDTOList = blogService.GetBlogList();
            BlogList blogList = new BlogList();
            int blogDTOCount = blogDTOList.Count();
            for (int i = 0; i < blogDTOCount; i++)
            {
                BlogDTO blogDTO = blogDTOList.GetBlog(i);
                Blog blog = MapDataModel(blogDTO);
                blogList.AddBlog(blog);
            }
            return blogList;
        }

        public ActionResult Index()
        {
            BlogList blogList = GetBlogListHelper();
            return View(blogList);
        }

        [HttpPost]
        public ActionResult Index(int[] Data)
        {
            if (Data == null || Data.Length != 2)
            {
                return RedirectToAction("Index");
            }
            int index = Data[0];
            object values = new
            {
                Index = index
            };
            if (Data[1] == 0)
            {
                return RedirectToAction("EditBlog", "Home", values);
            }
            bool deleteSuccessful = blogService.RemoveBlog(index);
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

        public ActionResult EditBlog(int Index)
        {
            BlogDTO blogDTO = blogService.GetBlog(Index);
            if (blogDTO == null)
            {
                return RedirectToAction("Index");
            }
            Blog blog = MapDataModel(blogDTO);
            BlogDict blogDict = new BlogDict(blog, Index);
            return View(blogDict);
        }

        [HttpPost]
        public ActionResult EditBlog(BlogDict blogDict)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            int index = blogDict.Index;
            Blog newBlog = blogDict.Blog;
            BlogDTO blogDTO = MapDataDTO(newBlog);
            bool updateSuccessful = blogService.UpdateBlog(index, blogDTO);
            if (!updateSuccessful)
            {
                ModelState.AddModelError("", "Updating blog failed...");
                return View();
            }
            return RedirectToAction("Index");
        }

    }
}