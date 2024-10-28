namespace CinemaApp.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using CinemaApp.Data.Models;
    using static CinemaApp.Common.EntityValidationConstants.MovieValidationConstants;
    using static CinemaApp.Common.ApplicationConstants;

    public class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.HasKey(m => m.Id);

            builder.Property(m => m.Title)
                .IsRequired()
                .HasMaxLength(TitleMaxLength);

            builder.Property(m => m.Genre)
                .IsRequired()
                .HasMaxLength(GenreMaxLength);

            builder.Property(m => m.Director)
                .IsRequired()
                .HasMaxLength(DirectorMaxLength);

            builder.Property(m => m.Description)
                .IsRequired()
                .HasMaxLength(DescriptionMaxLength);

            builder.Property(m => m.ImageUrl)
                .IsRequired(false)
                .HasMaxLength(MaxImageUrlLength)
                .HasDefaultValue(NoImageUrl);

            builder.HasData(this.SeedMovies());
        }

        public List<Movie> SeedMovies()
        {
            List<Movie> movies = new List<Movie>();

            movies.Add(new Movie
            {
                Title = "Harry Potter and the Prisoner of Azkaban",
                Genre = "Fantasy",
                Director = "Alfonso Cuarón",
                Duration = 120,
                Description = "Harry Potter, Ron and Hermione return to Hogwarts School of Witchcraft and Wizardry for their third year of study, where they delve into the mystery surrounding an escaped prisoner who poses a dangerous threat to the young wizard.",
            });

            movies.Add(new Movie
            {
                Title = "Three Amigos!",
                Genre = "Comedy",
                Director = "John Landis",
                Duration = 110,
                Description = "Three actors accept an invitation to a Mexican village to perform their onscreen bandit fighter roles, unaware that it is the real thing.",
            });

            movies.Add(new Movie
            {
                Title = "Alien",
                Genre = "Horror",
                Director = "Ridley Scott",
                Duration = 105,
                Description = "After investigating a mysterious transmission of unknown origin, the crew of a commercial spacecraft encounters a deadly lifeform.",
            });

            return movies;
        }
    }
}
