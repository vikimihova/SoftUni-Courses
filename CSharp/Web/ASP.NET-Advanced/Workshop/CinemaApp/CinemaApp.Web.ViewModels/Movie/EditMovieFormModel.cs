using AutoMapper;
using System.ComponentModel.DataAnnotations;

using static CinemaApp.Common.EntityValidationMessages.Movie;
using static CinemaApp.Common.EntityValidationConstants.MovieValidationConstants;
using CinemaApp.Services.Mapping;

namespace CinemaApp.Web.ViewModels.Movie
{
    public class EditMovieFormModel : IMapFrom<Data.Models.Movie>, IMapTo<Data.Models.Movie>, IHaveCustomMappings
    {
        [Required]
        public string Id { get; set; } = null!;

        [Required(ErrorMessage = TitleRequiredMessage)]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; } = null!;

        [Required(ErrorMessage = GenreRequiredMessage)]
        [MinLength(GenreMinLength)]
        [MaxLength(GenreMaxLength)]
        public string Genre { get; set; } = null!;

        [Required(ErrorMessage = ReleaseDateRequiredMessage)]
        public string ReleaseDate { get; set; } = null!;

        [Required(ErrorMessage = DurationRequiredMessage)]
        [Range(DurationMinValue, DurationMaxValue)]
        public int Duration { get; set; }

        [Required(ErrorMessage = DirectorRequiredMessage)]
        [MinLength(DirectorMinLength)]
        [MaxLength(DirectorMaxLength)]
        public string Director { get; set; } = null!;

        [Required]
        [MinLength(DescriptionMinLength)]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [MaxLength(MaxImageUrlLength)]
        public string? ImageUrl { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Data.Models.Movie, EditMovieFormModel>()
                .ForMember(d => d.ReleaseDate,
                    opt => opt.MapFrom(s => s.ReleaseDate.ToString(DateViewFormat)));

            configuration.CreateMap<EditMovieFormModel, Data.Models.Movie>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.ReleaseDate, opt => opt.Ignore());
        }
    }
}
