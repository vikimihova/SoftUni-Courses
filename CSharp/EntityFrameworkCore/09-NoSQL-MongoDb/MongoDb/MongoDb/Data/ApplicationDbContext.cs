using Microsoft.EntityFrameworkCore;
using MongoDB.EntityFrameworkCore.Extensions;

using MongoDb.Data.Models;

namespace MongoDb.Data
{
    // standard procedure, but requires an additional MongoDB client
    // DbSets are collections
    // Specify collection for each entity
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Film>().ToCollection("films");
        }

        public DbSet<Film> Films { get; set; }
    }
}
