using System.ComponentModel.DataAnnotations;

using static CinemaApp.Common.EntityValidationConstants.MovieValidationConstants;

namespace CinemaApp.Web.ViewModels.Movie
{
    public class AddMovieInputModel
    {
        [Required]
        [MinLength(2)]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; }

        [Required]
        [MaxLength(GenreMaxLength)]
        public string Genre { get; set; }

        [Required]
        public string ReleaseDate { get; set; } = null!;

        [Range(60, 200)]
        public int Duration { get; set; }

        [Required]
        [MaxLength(DirectorMaxLength)]
        public string Director { get; set; }

        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; }
    }
}
