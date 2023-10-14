using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Doorforyou.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Doorforyou.Data
{
    public class DoorforyouContext : IdentityDbContext
    {
        public DoorforyouContext(DbContextOptions<DoorforyouContext> options)
            : base(options)
        {
        }

        public DbSet<Door> Door { get; set; 
        }
    }
}
