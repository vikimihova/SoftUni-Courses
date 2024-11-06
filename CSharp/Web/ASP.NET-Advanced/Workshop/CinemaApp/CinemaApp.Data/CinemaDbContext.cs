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

        public virtual DbSet<Ticket> Tickets { get; set; }
                
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // pass the modelBuilder to the base constructor of IdentityDbContext
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly()); // apply entity type configurations
        }
    }
}
