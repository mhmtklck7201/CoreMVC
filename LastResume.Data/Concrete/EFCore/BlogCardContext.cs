using LastResume.Entity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LastResume.Data.Concrete.EFCore
{
    public class BlogCardContext:DbContext
    {
        
        public DbSet<BlogCard> BlogCards { get; set; }
 
        public DbSet<BlogCategory> BlogCategories { get; set; }
      
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-DP9B9AH;Initial Catalog=ResumeDataDB;Integrated Security=True;Pooling=False");
            //  optionsBuilder.UseSqlServer("Data Source=.\MSSQLSERVER2019;Initial Catalog=ResumeDataDB;User Id=mkalcik1;Password=Mhmt.01020304");

        }
    }



}
