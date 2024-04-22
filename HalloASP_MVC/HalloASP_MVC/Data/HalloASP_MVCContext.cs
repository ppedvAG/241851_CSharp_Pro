using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HalloASP_MVC.Models;

namespace HalloASP_MVC.Data
{
    public class HalloASP_MVCContext : DbContext
    {
        public HalloASP_MVCContext (DbContextOptions<HalloASP_MVCContext> options)
            : base(options)
        {
        }

        public DbSet<HalloASP_MVC.Models.Book> Book { get; set; } = default!;
    }
}
