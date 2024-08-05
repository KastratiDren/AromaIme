using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Data
{
    public class AppDbContext :DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        //Database Tabels
        public DbSet<Fragrance> Fragrances { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Scent> Scents { get; set; }
        public DbSet<Season> Seasons { get; set; }
        public DbSet<Longevity> Longevities { get; set; }
    }
}
