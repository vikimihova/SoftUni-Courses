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
                    Id = cinema.Id.ToString(),
                    Name = cinema.Name,
                    Location = cinema.Location,
                    Movies = cinema.CinemaMovies
                        .Select(cm => new MovieCinemaViewModel()
                        {
                            Title = cm.Movie.Title,
                            Genre = cm.Movie.Genre,
                            Duration = cm.Movie.Duration,
                            Description = cm.Movie.Description,
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

        // edit cinema
        public async Task<EditCinemaFormModel?> GetCinemaForEditByIdAsync(Guid id)
        {
            EditCinemaFormModel? cinemaModel = await this.cinemaRepository
                .GetAllAttached()
                .To<EditCinemaFormModel>()
                .FirstOrDefaultAsync(c => c.Id.ToLower() == id.ToString().ToLower());

            return cinemaModel;
        }

        public async Task<bool> EditCinemaAsync(EditCinemaFormModel model)
        {
            Cinema cinemaEntity = AutoMapperConfig.MapperInstance
                .Map<EditCinemaFormModel, Cinema>(model);

            bool result = await this.cinemaRepository.UpdateAsync(cinemaEntity);
            return result;
        }

        public async Task<DeleteCinemaViewModel> GetCinemaForDeleteByIdAsync(Guid id)
        {
            DeleteCinemaViewModel? cinemaToDelete = await this.cinemaRepository
                .GetAllAttached()
                .Where(c => c.IsDeleted == false)
                .To<DeleteCinemaViewModel>()
                .FirstOrDefaultAsync(c => c.Id.ToLower() == id.ToString().ToLower());

            return cinemaToDelete;
        }

        public async Task<bool> SoftDeleteCinemaAsync(string id)
        {
            Cinema? cinemaToDelete = await this.cinemaRepository
                .FirstOrDefaultAsync(c => c.Id.ToString().ToLower() == id.ToString().ToLower());
            if (cinemaToDelete == null)
            {
                return false;
            }

            cinemaToDelete.IsDeleted = true;
            return await this.cinemaRepository.UpdateAsync(cinemaToDelete);
        }
    }
}
