using CinemaApp.Web.ViewModels.Movie;
using System.Globalization;

namespace CinemaApp.Web.ViewModels.Cinema
{
    public class CinemaDetailsViewModel
    {
        public CinemaDetailsViewModel()
        {
            this.Movies = new HashSet<MovieCinemaViewModel>(); 
        }

        public string Id { get; set; } = null!;
        public string Name { get; set; }
        public string Location { get; set; }
        public IEnumerable<MovieCinemaViewModel> Movies { get; set; }
    }
}
