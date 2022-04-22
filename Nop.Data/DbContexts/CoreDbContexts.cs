using Microsoft.EntityFrameworkCore;
using Nop.Core.Domain.Blogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Data.DbContexts
{
    public class CoreDbContexts : DbContext
    {
        public CoreDbContexts(DbContextOptions<CoreDbContexts> options) : base(options)
        {
        }

        public DbSet<BlogPost> BlogPost { get; set; }
    }
}
