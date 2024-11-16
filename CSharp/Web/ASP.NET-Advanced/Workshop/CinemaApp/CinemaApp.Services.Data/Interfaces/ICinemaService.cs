using CinemaApp.Web.ViewModels.Cinema;

namespace CinemaApp.Services.Data.Interfaces
{
    public interface ICinemaService
    {
        Task<IEnumerable<CinemaIndexViewModel>> IndexGetAllOrderedByLocationAsync();

        Task AddCinemaAsync(CinemaCreateFormModel model);

        Task<CinemaDetailsViewModel?> GetCinemaDetailsByIdAsync(Guid id);

        Task<EditCinemaFormModel?> GetCinemaForEditByIdAsync(Guid id);

        Task<bool> EditCinemaAsync(EditCinemaFormModel model);

        Task<DeleteCinemaViewModel> GetCinemaForDeleteByIdAsync(Guid id);

        Task<bool> SoftDeleteCinemaAsync(string id);
    }
}
