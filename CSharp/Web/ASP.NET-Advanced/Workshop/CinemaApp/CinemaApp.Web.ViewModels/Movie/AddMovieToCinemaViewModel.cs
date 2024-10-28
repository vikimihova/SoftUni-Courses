using CinemaApp.Web.ViewModels.Cinema;
using System.ComponentModel.DataAnnotations;
using static CinemaApp.Common.EntityValidationConstants.MovieValidationConstants;

namespace CinemaApp.Web.ViewModels.Movie
{
    public class AddMovieToCinemaViewModel
    {
        public AddMovieToCinemaViewModel()
        {
            this.Cinemas = new List<CinemaCheckboxItemInputModel>();            
        }

        [Required]
        public string MovieId { get; set; }

        [Required]
        [MaxLength(TitleMaxLength)]
        public string MovieTitle { get; set; }

        public IList<CinemaCheckboxItemInputModel> Cinemas { get; set; }
    }
}
