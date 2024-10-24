using Microsoft.EntityFrameworkCore;
using CinemaApp.Data.Models;
using System.Reflection;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace CinemaApp.Data
{
    public class CinemaDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
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

        public virtual DbSet<ApplicationUserMovie> ApplicationUsersMovies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
