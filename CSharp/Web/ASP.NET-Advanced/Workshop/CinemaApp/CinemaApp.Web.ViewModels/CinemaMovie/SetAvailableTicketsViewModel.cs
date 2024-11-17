using CinemaApp.Services.Mapping;
using System.ComponentModel.DataAnnotations;

using static CinemaApp.Common.EntityValidationConstants.CinemaMovie;
using static CinemaApp.Common.EntityValidationMessages.CinemaMovie;

namespace CinemaApp.Web.ViewModels.CinemaMovie
{
    public class SetAvailableTicketsViewModel : IMapTo<Data.Models.CinemaMovie>
    {
        [Required]
        public string CinemaId { get; set; } = null!;

        [Required]
        public string MovieId { get; set; } = null!;

        [Required(ErrorMessage = AvailableTicketsRequiredMessage)]
        [Range(AvailableTicketsMinValue, AvailableTicketsMaxValue, ErrorMessage = AvailableTicketsRangeMessage)]
        public int AvailableTickets { get; set; }
    }
}
