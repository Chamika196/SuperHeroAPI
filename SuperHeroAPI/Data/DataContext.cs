global using Microsoft.EntityFrameworkCore;

namespace SuperHeroAPI.Data
{
    public class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server =.;Database=superheroapidb;Trusted_Connection=true;TrustServerCertificate=true;MultipleActiveResultSets=true;");

        }
        public DbSet<SuperHero> SuperHeros { get; set; }
    }

   
}
