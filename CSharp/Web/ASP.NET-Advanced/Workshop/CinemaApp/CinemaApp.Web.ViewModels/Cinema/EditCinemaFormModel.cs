using AutoMapper;
using CinemaApp.Services.Mapping;
using System.ComponentModel.DataAnnotations;

using static CinemaApp.Common.EntityValidationConstants.CinemaValidationConstants;

namespace CinemaApp.Web.ViewModels.Cinema 
{
    public class EditCinemaFormModel : IHaveCustomMappings
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

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration
                .CreateMap<Data.Models.Cinema, EditCinemaFormModel>();

            configuration
                .CreateMap<EditCinemaFormModel, Data.Models.Cinema>()
                .ForMember(d => d.Id, x => x.MapFrom(s => Guid.Parse(s.Id)));
        }
    }
}
