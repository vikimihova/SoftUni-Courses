﻿using CinemaApp.Services.Data.Interfaces;
using CinemaApp.Web.ViewModels.Cinema;
using CinemaApp.Web.ViewModels.CinemaMovie;
using Microsoft.AspNetCore.Mvc;

namespace CinemaApp.WebApi.Controllers
{
    [Route("[controller]/")]
    [ApiController]
    public class TicketApiController : ControllerBase
    {
        private readonly IManagerService managerService;
        private readonly ICinemaService cinemaService;
        private readonly ITicketService ticketService;

        public TicketApiController(IManagerService managerService, ICinemaService cinemaService,
            ITicketService ticketService)
        {
            this.managerService = managerService;
            this.cinemaService = cinemaService;
            this.ticketService = ticketService;
        }

        [HttpGet("[action]/{id?}")]
        [ProducesResponseType(typeof(CinemaDetailsViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetMoviesByCinema(string? id)
        {
            Guid cinemaGuid = Guid.Empty;
            if (!this.IsGuidValid(id, ref cinemaGuid))
            {
                return this.BadRequest();
            }

            CinemaDetailsViewModel? viewModel = await this.cinemaService
                .GetCinemaDetailsByIdAsync(cinemaGuid);
            if (viewModel == null)
            {
                return this.NotFound();
            }

            return this.Ok(viewModel);
        }

        [HttpPost("[action]")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateAvailableTickets([FromBody] SetAvailableTicketsViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest(ModelState);
            }

            bool isSuccess = await this.ticketService.SetAvailableTicketsAsync(model);
            if (!isSuccess)
            {
                return this.BadRequest();
            }

            return this.Ok("Ticket availability updated successfully!");
        }

        protected bool IsGuidValid(string? id, ref Guid parsedGuid)
        {
            // Non-existing parameter in the URL
            if (String.IsNullOrWhiteSpace(id))
            {
                return false;
            }

            // Invalid parameter in the URL
            bool isGuidValid = Guid.TryParse(id, out parsedGuid);
            if (!isGuidValid)
            {
                return false;
            }

            return true;
        }
    }
}
