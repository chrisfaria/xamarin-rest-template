using System;
using Microsoft.EntityFrameworkCore;

namespace xTemplate.API.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Item> Items { get; set; }
        public DbSet<SubItem> SubItems { get; set; }
    }
}
