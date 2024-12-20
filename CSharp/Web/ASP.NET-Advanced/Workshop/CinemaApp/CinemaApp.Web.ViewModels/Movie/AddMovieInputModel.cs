using AutoMapper;
using CinemaApp.Services.Mapping;
using System.ComponentModel.DataAnnotations;

using static CinemaApp.Common.EntityValidationConstants.MovieValidationConstants;

namespace CinemaApp.Web.ViewModels.Movie
{
    public class AddMovieInputModel : IMapTo<Data.Models.Movie>, IHaveCustomMappings
    {
        public AddMovieInputModel()
        {
            this.ReleaseDate = DateTime.UtcNow.ToString(DateViewFormat);
        }

        [Required(ErrorMessage = "Movie title is required.")]
        [MinLength(2)]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(GenreMaxLength)]
        public string Genre { get; set; } = null!;

        [Required]
        public string ReleaseDate { get; set; } = null!;

        [Range(60, 200)]
        public int Duration { get; set; }

        [Required]
        [MaxLength(DirectorMaxLength)]
        public string Director { get; set; } = null!;

        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [MaxLength(MaxImageUrlLength)]
        public string? ImageUrl {  get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<AddMovieInputModel, Data.Models.Movie>()
                .ForMember(d => d.ReleaseDate, x => x.Ignore());
        }
    }
}
