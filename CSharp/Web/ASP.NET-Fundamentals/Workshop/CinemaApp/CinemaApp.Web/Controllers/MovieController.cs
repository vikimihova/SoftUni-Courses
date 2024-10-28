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
        public IActionResult Index()
        {
            IEnumerable<Movie> allMovies = this.dbContext
                .Movies
                .ToList();

            return View(allMovies);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(AddMovieInputModel inputModel)
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

            this.dbContext.Movies.Add(movie);
            this.dbContext.SaveChanges();

            return this.RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Details(string Id)
        {
            bool isIdValid = Guid.TryParse(Id, out Guid id);

            if (!isIdValid)
            {
                return RedirectToAction(nameof(Index));
            }

            Movie? movie = this.dbContext.Movies.FirstOrDefault(x => x.Id == id);

            if (movie == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(movie);
        }

        [HttpGet]
        public IActionResult AddToProgram(string id)
        {
            Movie movie = this.dbContext.Movies.FirstOrDefault(m => m.Id.ToString() == id);

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
        public IActionResult AddToProgram(AddMovieToCinemaViewModel model) 
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            Movie? movie = dbContext.Movies.FirstOrDefault(m => m.Id.ToString() == model.MovieId);

            if (movie == null)
            {
                return View(model);
            }

            var entitiesToAdd = new List<CinemaMovie>();

            
            foreach (var cinemaCheckboxInputModel in model.Cinemas)
            {
                Cinema? cinema = dbContext.Cinemas.FirstOrDefault(c => c.Id.ToString() == cinemaCheckboxInputModel.Id);

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

            dbContext.CinemasMovies.AddRange(entitiesToAdd);
            dbContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
