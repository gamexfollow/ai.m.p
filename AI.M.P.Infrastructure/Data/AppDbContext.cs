using Microsoft.EntityFrameworkCore;
using AI.M.P.Core.Entities;
using System.Collections.Generic;

namespace AI.M.P.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Account> Accounts { get; set; } = null!;
    }
}
