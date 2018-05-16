using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.DAL.Entities
{
    public class BlogContext : DbContext
    {
        public DbSet<BlogEntity> Blogs { get; set; }
    }
}
