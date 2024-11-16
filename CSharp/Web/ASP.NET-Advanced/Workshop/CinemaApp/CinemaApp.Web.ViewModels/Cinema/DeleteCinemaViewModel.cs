using CinemaApp.Services.Mapping;

namespace CinemaApp.Web.ViewModels.Cinema
{
    public class DeleteCinemaViewModel : IMapFrom<Data.Models.Cinema>
    {
        public string Id { get; set; } = null!;

        public string? Name { get; set; }

        public string? Location { get; set; }
    }
}
