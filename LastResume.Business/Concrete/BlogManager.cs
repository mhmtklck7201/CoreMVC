using LastResume.Business.Abstract;
using LastResume.Data.Abstract;
using LastResume.Entity.Models;
using System.Runtime.Serialization;

namespace LastResume.Business.Concrete
{

    public class BlogManager : IBlogService
    {
        private IBlogRepository _blogRepository;
        public BlogManager(IBlogRepository blogRepository)
        {

            this._blogRepository = blogRepository;
        }

        public void AddBlogToDB(BlogCard blog)
        {
            //var index = _blogRepository.getAll().FindIndex(s => s.BlogID == blog.BlogID);
            //if (index < 0)
            //{
                _blogRepository.Create(blog);
            //}
        }

        public bool DeleteBlog(int BlogID)
        {
            bool result = false;
            if (!string.IsNullOrEmpty(BlogID.ToString()))
            {
                _blogRepository.DeleteFromDB(BlogID);
                result = true;  
            }
            return result;

        }

        public List<BlogCard> GetAllBlog()
        {
          return _blogRepository.getAll();
        }

        public BlogCard GetBlogByID(int BlogID)
        {
            BlogCard blogCard = null;
            if (!string.IsNullOrEmpty(BlogID.ToString()))
            {
                blogCard = _blogRepository.GetByBlogId(BlogID);
            }
            return blogCard;
        }
    }
}
