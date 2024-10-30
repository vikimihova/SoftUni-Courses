using CinemaApp.Data;
using CinemaApp.Data.Models;
using CinemaApp.Web.ViewModels.Cinema;
using CinemaApp.Web.ViewModels.Movie;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using static CinemaApp.Common.EntityValidationConstants.MovieValidationConstants;

namespace CinemaApp.Web.Controllers
{
    public class MovieController : Controller
    {
        private readonly CinemaDbContext dbContext;

        public MovieController(CinemaDbContext dbContext)
        {
             this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<Movie> allMovies = await this.dbContext
                .Movies
                .ToListAsync();

            return View(allMovies);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddMovieInputModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                //Render the same form with user entered values with errors
                return this.View(inputModel);
            }

            bool isReleaseDateValid = DateTime.TryParseExact(inputModel.ReleaseDate, DateViewFormat, 
                CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime releaseDate);

            if (!isReleaseDateValid)
            {
                //ModelState automatically becomes invalid
                this.ModelState.AddModelError(nameof(inputModel.ReleaseDate), String.Format("Release date must be in the following format: {0}", DateViewFormat));
                return this.View(inputModel);
            }

            Movie movie = new Movie()
            {
                Title = inputModel.Title,
                Genre = inputModel.Genre,
                ReleaseDate = releaseDate,
                Director = inputModel.Director,
                Duration = inputModel.Duration,
                Description = inputModel.Description,
                ImageUrl = inputModel.ImageUrl,
            };

            await this.dbContext.Movies.AddAsync(movie);
            await this.dbContext.SaveChangesAsync();

            return this.RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Details(string Id)
        {
            bool isIdValid = Guid.TryParse(Id, out Guid id);

            if (!isIdValid)
            {
                return RedirectToAction(nameof(Index));
            }

            Movie? movie = await this.dbContext.Movies.FirstOrDefaultAsync(x => x.Id == id);

            if (movie == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(movie);
        }

        [HttpGet]
        public async Task<IActionResult> AddToProgram(string id)
        {
            Movie? movie = await this.dbContext.Movies.FirstOrDefaultAsync(m => m.Id.ToString() == id);

            if (movie == null)
            {
                return RedirectToAction(nameof(Index));
            }

            AddMovieToCinemaViewModel model = new AddMovieToCinemaViewModel()
            {
                MovieId = movie.Id.ToString(),
                MovieTitle = movie.Title,
                Cinemas = dbContext
                            .Cinemas
                            .Include(c => c.CinemaMovies)
                            .ThenInclude(cm => cm.Movie)
                            //.Where(c => c.CinemaMovies.Any(cm => cm.Movie.Id == movie.Id))
                            .Select(c => new CinemaCheckboxItemInputModel()
                            {
                                Id = c.Id.ToString(),
                                Name = c.Name,
                                Location = c.Location,
                                IsSelected = c.CinemaMovies
                                    .Any(cm => cm.Movie.Id == movie.Id)
                            })
                            .ToArray()
            };             

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddToProgram(AddMovieToCinemaViewModel model) 
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            Movie? movie = await dbContext.Movies.FirstOrDefaultAsync(m => m.Id.ToString() == model.MovieId);

            if (movie == null)
            {
                return View(model);
            }

            var entitiesToAdd = new List<CinemaMovie>();

            
            foreach (var cinemaCheckboxInputModel in model.Cinemas)
            {
                Cinema? cinema = await dbContext.Cinemas.FirstOrDefaultAsync(c => c.Id.ToString() == cinemaCheckboxInputModel.Id);

                if (cinema == null || 
                    cinemaCheckboxInputModel.IsSelected == false ||
                    cinema.CinemaMovies.Any(cm => cm.Movie == movie))
                {
                    continue;
                }

                entitiesToAdd.Add(new CinemaMovie()
                {
                    Movie = movie,
                    Cinema = cinema,
                });
            }

            await dbContext.CinemasMovies.AddRangeAsync(entitiesToAdd);
            await dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
