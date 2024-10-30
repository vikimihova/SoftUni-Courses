using Microsoft.EntityFrameworkCore;
using CinemaApp.Data.Models;
using CinemaApp.Data.Repository.Interfaces;
using CinemaApp.Services.Data.Interfaces;
using CinemaApp.Services.Mapping;
using CinemaApp.Web.ViewModels.Cinema;
using CinemaApp.Web.ViewModels.Movie;

namespace CinemaApp.Services.Data
{
    public class CinemaService : ICinemaService
    {
        // DEPENCENCY INJECTION - repositories

        private readonly IRepository<Cinema, Guid> cinemaRepository;
        public CinemaService(IRepository<Cinema, Guid> _cinemaRepository)
        {
            this.cinemaRepository = _cinemaRepository;            
        }

        // BUSINESS LOGIC

        // add cinema
        public async Task AddCinemaAsync(CinemaCreateFormModel model)
        {
            Cinema cinema = new Cinema();
            AutoMapperConfig.MapperInstance.Map(model, cinema);

            await this.cinemaRepository.AddAsync(cinema);
        }

        // get cinema details
        public async Task<CinemaDetailsViewModel?> GetCinemaDetailsByIdAsync(Guid id)
        {
            Cinema? cinema = await this.cinemaRepository
                .GetAllAttached()
                .Include(c => c.CinemaMovies)
                .ThenInclude(cm => cm.Movie)
                .FirstOrDefaultAsync(c => c.Id == id);

            CinemaDetailsViewModel? model = null;

            if (cinema != null)
            {
                model = new CinemaDetailsViewModel()
                {
                    Name = cinema.Name,
                    Location = cinema.Location,
                    Movies = cinema.CinemaMovies
                        .Select(cm => new MovieCinemaViewModel()
                        {
                            Title = cm.Movie.Title,
                            Duration = cm.Movie.Duration,
                        })
                        .ToArray()
                };
            }     
            
            return model;
        }

        // get all cinemas
        public async Task<IEnumerable<CinemaIndexViewModel>> IndexGetAllOrderedByLocationAsync()
        {
            IEnumerable<CinemaIndexViewModel> cinemas = await this.cinemaRepository
                .GetAllAttached()
                .OrderBy(x => x.Location)
                .To<CinemaIndexViewModel>()
                .ToArrayAsync();

            return cinemas;
        }
    }
}
