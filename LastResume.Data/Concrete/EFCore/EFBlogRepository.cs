using LastResume.Data.Abstract;
using LastResume.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LastResume.Data.Concrete.EFCore
{
    public class EFBlogRepository : EfCoreGenericRepository<BlogCard, BlogCardContext>, IBlogRepository
    {
        public void DeleteFromDB(int userId)
        {
            using (var context = new BlogCardContext())
            {
                var item = context.BlogCards.Where(s => s.Id == userId).FirstOrDefault();
            }
        }

        public BlogCard GetByBlogId(int userId)
        {
            BlogCard card = null;
            using (var context = new BlogCardContext())
            {
                card = context.BlogCards.Where(s => s.Id == userId).FirstOrDefault();
            }
            return card;
        }
    }
}
