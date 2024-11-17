using CinemaApp.Services.Mapping;
using System.ComponentModel.DataAnnotations;

using static CinemaApp.Common.EntityValidationConstants.Ticket;
using static CinemaApp.Common.EntityValidationMessages.Ticket;

namespace CinemaApp.Web.ViewModels.Ticket
{
    public class BuyTicketViewModel : IMapTo<Data.Models.Ticket>
    {
        [Required]
        public string CinemaId { get; set; } = null!;

        [Required]
        public string MovieId { get; set; } = null!;
        [Required]
        public string UserId { get; set; } = null!;

        [Range(typeof(decimal), PriceMinValue, PriceMaxValue, ErrorMessage = IncorrectPriceMessage)]
        public decimal Price { get; set; }

        [Range(CountMinValue, CountMaxValue, ErrorMessage = IncorrectCountMessage)]
        public int Count { get; set; }
    }
}
