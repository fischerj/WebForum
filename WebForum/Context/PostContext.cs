using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebForum.Models;

namespace WebForum.Context
{
    class PostContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }
    }
}
