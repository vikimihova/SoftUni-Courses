using System.ComponentModel.DataAnnotations;
using static CinemaApp.Common.EntityValidationConstants.CinemaValidationConstants;

namespace CinemaApp.Web.ViewModels.Cinema
{
    public class CinemaCheckboxItemInputModel
    {
        [Required]
        public string Id { get; set; } = null!;

        [Required]
        [MinLength(NameMinLength)]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        [MinLength(LocationMinLength)]
        [MaxLength(LocationMaxLength)]
        public string Location { get; set; } = null!;

        public bool IsSelected { get; set; } // false by default
    }
}
