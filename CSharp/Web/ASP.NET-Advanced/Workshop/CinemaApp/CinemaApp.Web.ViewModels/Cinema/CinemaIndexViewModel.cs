using CinemaApp.Services.Mapping;

namespace CinemaApp.Web.ViewModels.Cinema
{
    public class CinemaIndexViewModel : IMapFrom<Data.Models.Cinema>
    {
        public string Id { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string Location { get; set; } = null!;
    }
}
