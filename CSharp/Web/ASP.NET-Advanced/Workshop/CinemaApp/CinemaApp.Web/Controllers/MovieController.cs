using CinemaApp.Data;
using CinemaApp.Data.Models;
using CinemaApp.Services.Data.Interfaces;
using CinemaApp.Web.Infrastructure.Extensions;
using CinemaApp.Web.ViewModels.Cinema;
using CinemaApp.Web.ViewModels.Movie;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using static CinemaApp.Common.EntityValidationConstants.MovieValidationConstants;

namespace CinemaApp.Web.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieService movieService;
        protected readonly IManagerService managerService;

        public MovieController(IMovieService movieService, IManagerService managerService)
        {
            this.movieService = movieService;
            this.managerService = managerService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            //IEnumerable<Movie> allMovies = await this.dbContext
            //    .Movies
            //    .ToListAsync();

            IEnumerable<MovieViewModel> allMovies = await this.movieService.IndexGetAllMoviesAsync();

            return View(allMovies);
        }

        [HttpGet]
        [Authorize]
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
        [Authorize]
        public async Task<IActionResult> Create(AddMovieInputModel inputModel)
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
            if (!this.ModelState.IsValid)
            {
                //Render the same form with user entered values with errors
                return this.View(inputModel);
            }

            bool result = await this.movieService.AddMovieAsync(inputModel);

            if (result == false)
            {
                this.ModelState.AddModelError(nameof(inputModel.ReleaseDate), String.Format("Release date must be in the following format: {0}", DateViewFormat));
                return this.View(inputModel);
            }            

            return this.RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            bool isIdValid = Guid.TryParse(id, out Guid guidId);

            if (!isIdValid)
            {
                return RedirectToAction(nameof(Index));
            }

            MovieDetailsViewModel? model = await this.movieService.GetMovieDetailsByIdAsync(guidId);

            if (model == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> AddToProgram(string id)
        {
            // check if user is manager
            string? userId = this.User.GetUserId();
            bool isManager = await this.managerService
                .IsUserManagerAsync(userId);

            if (!isManager)
            {
                return this.RedirectToAction(nameof(Index));
            }

            // check guid
            Guid movieGuid = Guid.Empty;
            bool isGuidValid = this.IsGuidValid(id, ref movieGuid);
            if (!isGuidValid)
            {
                return this.RedirectToAction(nameof(Index));
            }

            AddMovieToCinemaViewModel? model = await this.movieService
                .GetAddMovieToCinemaInputModelByIdAsync(movieGuid);
            if (model == null)
            {
                return this.RedirectToAction(nameof(Index));
            }

            return this.View(model);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddToProgram(AddMovieToCinemaViewModel model) 
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
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            Guid movieGuid = Guid.Empty;
            bool isGuidValid = this.IsGuidValid(model.MovieId, ref movieGuid);
            if (!isGuidValid)
            {
                return this.RedirectToAction(nameof(Index));
            }

            bool result = await this.movieService
                .AddMovieToCinemasAsync(movieGuid, model);
            if (result == false)
            {
                return this.RedirectToAction(nameof(Index));
            }

            return this.RedirectToAction(nameof(Index), "Cinema");
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
