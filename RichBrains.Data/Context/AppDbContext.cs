using Microsoft.EntityFrameworkCore;
using RichBrains.Data.Models;

namespace RichBrains.Data.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options: options)
        {

        }

        public DbSet<UserDb> Users { get; set; }
    }
}
