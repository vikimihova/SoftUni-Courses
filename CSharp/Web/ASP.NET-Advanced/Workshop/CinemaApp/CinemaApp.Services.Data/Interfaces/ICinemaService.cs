using CinemaApp.Web.ViewModels.Cinema;

namespace CinemaApp.Services.Data.Interfaces
{
    public interface ICinemaService
    {
        Task<IEnumerable<CinemaIndexViewModel>> IndexGetAllOrderedByLocationAsync();

        Task AddCinemaAsync(CinemaCreateFormModel model);

        Task<CinemaDetailsViewModel?> GetCinemaDetailsByIdAsync(Guid id);
    }
}
