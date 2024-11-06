using Microsoft.EntityFrameworkCore;
using CinemaApp.Services.Mapping;
using CinemaApp.Data.Models;
using CinemaApp.Data.Repository;
using CinemaApp.Data.Repository.Interfaces;
using CinemaApp.Services.Data.Interfaces;
using CinemaApp.Web.ViewModels.Movie;
using System.Globalization;

using static CinemaApp.Common.EntityValidationConstants.MovieValidationConstants;
using CinemaApp.Web.ViewModels.Cinema;

namespace CinemaApp.Services.Data
{
    public class MovieService : BaseService, IMovieService
    {
        private readonly IRepository<Movie, Guid> movieRepository;
        private readonly IRepository<Cinema, Guid> cinemaRepository;
        private readonly IRepository<CinemaMovie, object> cinemaMovieRepository;

        public MovieService(IRepository<Movie, Guid> _movieRepository)
        {
            this.movieRepository = _movieRepository;
        }

        // BUSINESS LOGIC

        // Index get all
        public async Task<IEnumerable<MovieViewModel>> IndexGetAllMoviesAsync()
        {
            IEnumerable<MovieViewModel> movies = await this.movieRepository
                .GetAllAttached()
                .To<MovieViewModel>()
                .ToArrayAsync();

            return movies;
        }

        // Add movie
        public async Task<bool> AddMovieAsync(AddMovieInputModel inputModel)
        {
            bool isReleaseDateValid = DateTime.TryParseExact(inputModel.ReleaseDate, DateViewFormat,
                CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime releaseDate);

            if (!isReleaseDateValid)
            {
                //ModelState automatically becomes invalid
                return false;
            }

            Movie movie = new Movie();
            AutoMapperConfig.MapperInstance.Map(inputModel, movie);
            movie.ReleaseDate = releaseDate;

            await this.movieRepository.AddAsync(movie);

            return true;
        }

        // Add movie to cinema
        public async Task<bool> AddMovieToCinemasAsync(Guid movieId, AddMovieToCinemaViewModel model)
        {
            Movie? movie = await this.movieRepository
                .GetByIdAsync(movieId);
            if (movie == null)
            {
                return false;
            }

            ICollection<CinemaMovie> entitiesToAdd = new List<CinemaMovie>();
            foreach (CinemaCheckboxItemInputModel cinemaInputModel in model.Cinemas)
            {
                Guid cinemaGuid = Guid.Empty;
                bool isCinemaGuidValid = this.IsGuidValid(cinemaInputModel.Id, ref cinemaGuid);
                if (!isCinemaGuidValid)
                {
                    return false;
                }

                Cinema? cinema = await this.cinemaRepository
                    .GetByIdAsync(cinemaGuid);
                if (cinema == null)
                {
                    return false;
                }

                CinemaMovie? cinemaMovie = await this.cinemaMovieRepository
                    .FirstOrDefaultAsync(cm => cm.MovieId == movieId &&
                                                     cm.CinemaId == cinemaGuid);
                if (cinemaInputModel.IsSelected)
                {
                    if (cinemaMovie == null)
                    {
                        entitiesToAdd.Add(new CinemaMovie()
                        {
                            Cinema = cinema,
                            Movie = movie
                        });
                    }
                }
            }

            await this.cinemaMovieRepository.AddRangeAsync(entitiesToAdd.ToArray());

            return true;
        }

        public async Task<AddMovieToCinemaViewModel?> GetAddMovieToCinemaInputModelByIdAsync(Guid id)
        {
            Movie? movie = await this.movieRepository
                .GetByIdAsync(id);
            AddMovieToCinemaViewModel? viewModel = null;
            if (movie != null)
            {
                viewModel = new AddMovieToCinemaViewModel()
                {
                    MovieId = id.ToString(),
                    MovieTitle = movie.Title,
                    Cinemas = await this.cinemaRepository
                        .GetAllAttached()
                        .Include(c => c.CinemaMovies)
                    .ThenInclude(cm => cm.Movie)
                        .Select(c => new CinemaCheckboxItemInputModel()
                        {
                            Id = c.Id.ToString(),
                            Name = c.Name,
                            Location = c.Location,
                            IsSelected = c.CinemaMovies
                                .Any(cm => cm.Movie.Id == id)
                        })
                        .ToArrayAsync()
                };
            }

            return viewModel;
        }

        // Movie details
        public async Task<MovieDetailsViewModel?> GetMovieDetailsByIdAsync(Guid id)
        {
            Movie? movie = await this.movieRepository
                .GetByIdAsync(id);
            MovieDetailsViewModel? viewModel = null;
            if (movie != null)
            {
                AutoMapperConfig.MapperInstance.Map(movie, viewModel);
            }

            return viewModel;
        }        
    }
}
