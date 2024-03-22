using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CVApp.Server.Model;

namespace CVApp.Server.Data
{
    public class CVAppDbContext : DbContext
    {
        public CVAppDbContext (DbContextOptions<CVAppDbContext> options)
            : base(options)
        {
        }

        public DbSet<CVApp.Server.Model.User> User { get; set; } = default!;
    }
}
