using AutoMapper;
using CinemaApp.Data.Models;
using CinemaApp.Services.Mapping;
using static CinemaApp.Common.EntityValidationConstants.MovieValidationConstants;

namespace CinemaApp.Web.ViewModels.Watchlist
{
    public class WatchlistViewModel : IMapFrom<Data.Models.ApplicationUserMovie>, IHaveCustomMappings
    {
        public string MovieId { get; set; } = null!;

        public string Title { get; set; } = null!;

        public string Genre { get; set; } = null!;

        public string ReleaseDate { get; set; } = null!;

        public string? ImageUrl { get; set; } = null!;

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration
                .CreateMap<ApplicationUserMovie, WatchlistViewModel>()
                .ForMember(d => d.MovieId, x => x.MapFrom(s => s.MovieId.ToString()))
                .ForMember(d => d.Title, x => x.MapFrom(s => s.Movie.Title))
                .ForMember(d => d.Genre, x => x.MapFrom(s => s.Movie.Genre))
                .ForMember(d => d.ReleaseDate, x => x.MapFrom(s => s.Movie.ReleaseDate.ToString(DateViewFormat)))
                .ForMember(d => d.ImageUrl, x => x.MapFrom(s => s.Movie.ImageUrl));
        }
    }
}
