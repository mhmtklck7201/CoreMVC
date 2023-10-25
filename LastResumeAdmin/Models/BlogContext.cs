using LastResume.Entity.Models;
using Microsoft.EntityFrameworkCore;

namespace LastResumeAdmin.Models
{
    public class BlogContext : DbContext
    {
        public BlogContext(DbContextOptions<BlogContext> options) : base(options)
        {

        }
     
    }
}
