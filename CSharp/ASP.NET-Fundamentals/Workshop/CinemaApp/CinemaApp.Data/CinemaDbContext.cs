using Microsoft.EntityFrameworkCore;
using CinemaApp.Data.Models;
using System.Reflection;

namespace CinemaApp.Data
{
    public class CinemaDbContext : DbContext
    {
        public CinemaDbContext()
        {            
        }

        public CinemaDbContext(DbContextOptions options) : base(options)
        {            
        }

        public virtual DbSet<Movie> Movies { get; set; }

        public virtual DbSet<Cinema> Cinemas { get; set; }

        public virtual DbSet<CinemaMovie> CinemasMovies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
