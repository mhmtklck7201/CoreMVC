using LastResume.Entity.Models;
 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LastResume.Business.Abstract
{
    public  interface IBlogService
    {
        void AddBlogToDB(BlogCard blog);
        bool DeleteBlog(int BlogID);

        List<BlogCard> GetAllBlog();
        BlogCard GetBlogByID(int BlogID);

    }
}
