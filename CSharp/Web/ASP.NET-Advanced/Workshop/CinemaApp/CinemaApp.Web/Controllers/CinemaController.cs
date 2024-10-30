using CinemaApp.Data;
using CinemaApp.Data.Models;
using CinemaApp.Services.Data.Interfaces;
using CinemaApp.Web.ViewModels.Cinema;
using CinemaApp.Web.ViewModels.Movie;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CinemaApp.Web.Controllers
{
    public class CinemaController : Controller
    {
        private readonly CinemaDbContext dbContext;
        private readonly ICinemaService cinemaService;

        public CinemaController(CinemaDbContext dbContext, ICinemaService cinemaService)
        {
            this.dbContext = dbContext;
            this.cinemaService = cinemaService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<CinemaIndexViewModel> cinemas = 
                await this.cinemaService.IndexGetAllOrderedByLocationAsync();

            return View(cinemas);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CinemaCreateFormModel model)
        {
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

    }
}
