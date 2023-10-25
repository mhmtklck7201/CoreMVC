using LastResume.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LastResume.Data.Abstract
{
    public interface IBlogRepository : IGenericRepository<BlogCard>
    {
        BlogCard GetByBlogId(int userId);
        void DeleteFromDB(int userId);
    }
}
