using CinemaApp.Data;
using CinemaApp.Data.Models;
using CinemaApp.Services.Data.Interfaces;
using CinemaApp.Web.Infrastructure.Extensions;
using CinemaApp.Web.ViewModels.Cinema;
using CinemaApp.Web.ViewModels.Movie;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CinemaApp.Web.Controllers
{
    public class CinemaController : Controller
    {
        private readonly ICinemaService cinemaService;
        private readonly IManagerService managerService;

        public CinemaController(ICinemaService cinemaService, IManagerService managerService)
        {
            this.cinemaService = cinemaService;
            this.managerService = managerService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<CinemaIndexViewModel> cinemas = 
                await this.cinemaService.IndexGetAllOrderedByLocationAsync();

            return View(cinemas);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            // check if user is manager
            string? userId = this.User.GetUserId();
            bool isManager = await this.managerService
                .IsUserManagerAsync(userId);

            if (!isManager)
            {
                return this.RedirectToAction(nameof(Index));
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CinemaCreateFormModel model)
        {
            // check if user is manager
            string? userId = this.User.GetUserId();
            bool isManager = await this.managerService
                .IsUserManagerAsync(userId);

            if (!isManager)
            {
                return this.RedirectToAction(nameof(Index));
            }

            // check model state
            if (!ModelState.IsValid) 
            {
                return View(model);
            }

            await this.cinemaService.AddCinemaAsync(model);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            if (String.IsNullOrWhiteSpace(id))
            {
                return RedirectToAction(nameof(Index));
            }

            bool isIdValid = Guid.TryParse(id, out Guid idGuid);

            if (!isIdValid)
            {
                return RedirectToAction(nameof(Index));
            }

            CinemaDetailsViewModel? model = await this.cinemaService.GetCinemaDetailsByIdAsync(idGuid);

            if (model == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Manage()
        {
            // check if user is manager
            string? userId = this.User.GetUserId();
            bool isManager = await this.managerService
                .IsUserManagerAsync(userId);

            if (!isManager)
            {
                return this.RedirectToAction(nameof(Index));
            }

            IEnumerable<CinemaIndexViewModel> cinemas =
                await this.cinemaService.IndexGetAllOrderedByLocationAsync();

            return this.View(cinemas);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Edit(string? id)
        {
            // check if user is manager
            string? userId = this.User.GetUserId();
            bool isManager = await this.managerService
                .IsUserManagerAsync(userId);

            if (!isManager)
            {
                // TODO: Implement notifications for error and warning messages!
                return this.RedirectToAction(nameof(Index));
            }

            bool isIdValid = Guid.TryParse(id, out Guid idGuid);

            if (!isIdValid)
            {
                return this.RedirectToAction(nameof(Index));
            }

            EditCinemaFormModel? formModel = await this.cinemaService
                .GetCinemaForEditByIdAsync(idGuid);

            return this.View(formModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Edit(EditCinemaFormModel formModel)
        {
            // check if user is manager
            string? userId = this.User.GetUserId();
            bool isManager = await this.managerService
                .IsUserManagerAsync(userId);

            if (!isManager)
            {
                return this.RedirectToAction(nameof(Index));
            }

            if (!ModelState.IsValid)
            {
                return this.View(formModel);
            }

            bool isUpdated = await this.cinemaService
                .EditCinemaAsync(formModel);
            if (!isUpdated)
            {
                ModelState.AddModelError(string.Empty, "Unexpected error occurred while updating the cinema! Please contact administrator");
                return this.View(formModel);
            }

            return this.RedirectToAction(nameof(Details), "Cinema", new { id = formModel.Id });
        }
    }
}
