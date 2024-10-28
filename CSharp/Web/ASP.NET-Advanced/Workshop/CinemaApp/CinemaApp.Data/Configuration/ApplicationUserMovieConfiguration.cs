using CinemaApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaApp.Data.Configuration
{
    public class ApplicationUserMovieConfiguration : IEntityTypeConfiguration<ApplicationUserMovie>
    {
        public void Configure(EntityTypeBuilder<ApplicationUserMovie> builder)
        {
            builder.HasKey(aum => new { aum.ApplicationUserId, aum.MovieId });

            builder.HasOne(aum => aum.Movie)
                .WithMany(m => m.MovieUsers)
                .HasForeignKey(aum => aum.MovieId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(aum => aum.ApplicationUser)
                .WithMany(au => au.UserMovies)
                .HasForeignKey(aum => aum.ApplicationUserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
