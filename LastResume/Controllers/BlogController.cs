using LastResume.Business.Abstract;
using LastResume.Data.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace LastResume.Controllers
{
    public class BlogController : Controller
    {
        private IBlogService _blogRepo;
        public BlogController(IBlogService blogRepository)
        {
            _blogRepo=blogRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult GetBlogs()
        {
            var blogs = _blogRepo.GetAllBlog();
            return View(blogs);
        }
        [HttpGet]
        public IActionResult BlogDetail(int id)
        { 
            var blog=_blogRepo.GetBlogByID(id);
            return View(blog);
        }
        }
}
