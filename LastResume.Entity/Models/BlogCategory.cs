using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LastResume.Entity.Models
{
    public class BlogCategory
    {
     
        public int Id { get; set; }
        public string? CategoryName { get; set; }
        public string? CategoryDescription { get; set; } = string.Empty;
        public List<BlogCard>? BlogCards { get; set; }
    }
}
