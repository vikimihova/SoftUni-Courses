using CinemaApp.Data;
using CinemaApp.Data.Models;
using CinemaApp.Web.ViewModels.Watchlist;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CinemaApp.Web.Controllers
{
    [Authorize]
    public class WatchlistController : Controller
    {
        private readonly CinemaDbContext dbContext;
        private readonly UserManager<ApplicationUser> userManager;

        public WatchlistController(CinemaDbContext dbContext, UserManager<ApplicationUser> userManager)
        {
            this.dbContext = dbContext;
            this.userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            string userId = this.userManager.GetUserId(User);

            
            IEnumerable<WatchlistViewModel> model = dbContext.ApplicationUsersMovies
                .Include(aum => aum.Movie)
                .Where(aum => aum.ApplicationUserId.ToString() == userId)
                .Select(aum => new WatchlistViewModel
                {
                    MovieId = aum.MovieId.ToString(),
                    Title = aum.Movie.Title,
                    Genre = aum.Movie.Genre,
                    ReleaseDate = aum.Movie.ReleaseDate.ToString(),
                    ImageUrl = aum.Movie.ImageUrl,
                })
                .ToList();

            return View(model);
        }

        [HttpPost]
        public IActionResult AddToWatchlist(string movieId)
        {
            Movie? movie = this.dbContext.Movies
                .FirstOrDefault(m => m.Id.ToString() == movieId);

            if (movie == null)
            {
                return RedirectToAction("Index", "Movie");
            }

            string userId = this.userManager.GetUserId(this.User)!;

            bool existsInWatchlist = dbContext.ApplicationUsersMovies
                .Where(aum => aum.ApplicationUserId.ToString() == userId)
                .Any(aum => aum.MovieId.ToString() == movieId);

            if (!existsInWatchlist) 
            {
                var userMovie = new ApplicationUserMovie()
                {
                    MovieId = Guid.Parse(movieId),
                    ApplicationUserId = Guid.Parse(userId),
                };

                dbContext.ApplicationUsersMovies.Add(userMovie);
                dbContext.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult RemoveFromWatchlist(string movieId)
        {
            string userId = this.userManager.GetUserId(this.User)!;

            var userMovie = dbContext.ApplicationUsersMovies.
                FirstOrDefault(aum => aum.MovieId.ToString() == movieId &&
                aum.ApplicationUserId.ToString() == userId);

            dbContext.ApplicationUsersMovies.Remove(userMovie);
            dbContext.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
