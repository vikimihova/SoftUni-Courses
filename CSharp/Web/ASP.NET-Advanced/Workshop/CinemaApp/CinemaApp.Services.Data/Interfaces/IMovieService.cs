using CinemaApp.Web.ViewModels.Movie;

namespace CinemaApp.Services.Data.Interfaces
{
    public interface IMovieService
    {
        Task<IEnumerable<MovieViewModel>> IndexGetAllMoviesAsync();

        Task<bool> AddMovieAsync(AddMovieInputModel inputModel);

        Task<MovieDetailsViewModel?> GetMovieDetailsByIdAsync(Guid id);

        Task<AddMovieToCinemaViewModel?> GetAddMovieToCinemaInputModelByIdAsync(Guid id);

        Task<bool> AddMovieToCinemasAsync(Guid movieId, AddMovieToCinemaViewModel model);

        Task<EditMovieFormModel?> GetEditMovieFormModelByIdAsync(Guid id);

        Task<bool> EditMovieAsync(EditMovieFormModel formModel);
    }
}
