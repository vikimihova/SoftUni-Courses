using CinemaApp.Data.Models;
using CinemaApp.Data.Repository.Interfaces;
using CinemaApp.Services.Data.Interfaces;
using CinemaApp.Web.ViewModels.Watchlist;

namespace CinemaApp.Services.Data
{
    public class WatchlistService : BaseService, IWatchlistService
    {
        private readonly IRepository<ApplicationUserMovie, object> userMovieRepository;
        private readonly IRepository<Movie, Guid> movieRepository;

        public WatchlistService(IRepository<ApplicationUserMovie, object> userMovieRepository,
            IRepository<Movie, Guid> movieRepository)
        {
            this.userMovieRepository = userMovieRepository;
            this.movieRepository = movieRepository;
        }

        public Task<bool> AddMovieToUserWatchListAsync(string? movieId, string userId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<WatchlistViewModel>> GetUserWatchListByUserIdAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveMovieFromUserWatchListAsync(string? movieId, string userId)
        {
            throw new NotImplementedException();
        }
    }
}
