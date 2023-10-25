using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LastResume.Entity.Models
{
    public  class BlogCard
    {
      
        public int Id { get; set; }
        public string? BlogTitle { get; set; }
        public string? BlogShortDesc { get; set; }
        public string? BlogLongDesc { get; set; }
        public string? BlogLink { get; set; }
        public string? BlogKeyWords { get; set; }
        public  BlogCategory? BlogCategory { get; set; }
    }
}
