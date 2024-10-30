using CinemaApp.Services.Mapping;
using System.ComponentModel.DataAnnotations;
using static CinemaApp.Common.EntityValidationConstants.CinemaValidationConstants;


namespace CinemaApp.Web.ViewModels.Cinema
{
    public class CinemaCreateFormModel : IMapTo<Data.Models.Cinema>
    {
        [Required]
        [MinLength(NameMinLength)]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        [MinLength(LocationMinLength)]
        [MaxLength(LocationMaxLength)]
        public string Location { get; set; } = null!;
    }
}
