﻿using CinemaApp.Data.Repository.Interfaces;
using CinemaApp.Services.Data.Interfaces;
using CinemaApp.Services.Mapping;
using CinemaApp.Web.ViewModels.CinemaMovie;
using CinemaApp.Data.Models;

namespace CinemaApp.Services.Data
{
    public class TicketService : BaseService, ITicketService
    {
        private readonly IRepository<CinemaMovie, object> cinemaMovieRepository;

        public TicketService(IRepository<CinemaMovie, object> cinemaMovieRepository)
        {
            this.cinemaMovieRepository = cinemaMovieRepository;
        }

        public async Task<bool> SetAvailableTicketsAsync(SetAvailableTicketsViewModel model)
        {
            CinemaMovie cinemaMovie = AutoMapperConfig.MapperInstance
                .Map<CinemaMovie>(model);

            return await this.cinemaMovieRepository.UpdateAsync(cinemaMovie);
        }
    }
}
