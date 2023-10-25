using Microsoft.EntityFrameworkCore;

namespace LastResume.Models
{
    public class BlogContext:DbContext
    {
        public BlogContext(DbContextOptions<BlogContext> options) : base(options)
        {

        }
    }
}
