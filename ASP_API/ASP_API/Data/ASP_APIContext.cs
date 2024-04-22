using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ASP_API;

namespace ASP_API.Data
{
    public class ASP_APIContext : DbContext
    {
        public ASP_APIContext (DbContextOptions<ASP_APIContext> options)
            : base(options)
        {
        }

        public DbSet<ASP_API.Book> Book { get; set; } = default!;
    }
}
