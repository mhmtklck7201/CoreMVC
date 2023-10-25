using LastResume.Data.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace LastResumeAdmin.Views.Components
{
    public class AllBlogs:ViewComponent
    {
        private IBlogRepository _blogRepo;
        public AllBlogs(IBlogRepository blogRepo)
        {
            _blogRepo = blogRepo;
            
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var blog = _blogRepo.getAll();
            return View(blog);
        }
    }
}
