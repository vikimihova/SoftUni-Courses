﻿using CinemaApp.Services.Mapping;

namespace CinemaApp.Web.ViewModels.Movie
{
    public class MovieCinemaViewModel : IMapFrom<Data.Models.Movie>
    {
        public string Id { get; set; } = null!;

        public string Title { get; set; } = null!;

        public string Genre { get; set; } = null!;

        public int Duration { get; set; }

        public string Description { get; set; } = null!;

        public int AvailableTickets { get; set; }
    }
}
