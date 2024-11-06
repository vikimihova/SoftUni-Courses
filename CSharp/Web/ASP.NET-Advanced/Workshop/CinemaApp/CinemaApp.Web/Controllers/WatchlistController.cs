using CinemaApp.Data;
using CinemaApp.Data.Models;
using CinemaApp.Services.Data.Interfaces;
using CinemaApp.Web.ViewModels.Watchlist;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using static CinemaApp.Common.ErrorMessages.Watchlist;

namespace CinemaApp.Web.Controllers
{
    [Authorize]
    public class WatchlistController : Controller
    {
        private readonly IWatchlistService watchlistService;

        private readonly CinemaDbContext dbContext;
        private readonly UserManager<ApplicationUser> userManager;

        public WatchlistController(IWatchlistService watchlistService, CinemaDbContext dbContext, UserManager<ApplicationUser> userManager)
        {
            this.watchlistService = watchlistService;
            this.dbContext = dbContext;
            this.userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            // get user id
            string? userId = this.userManager.GetUserId(User);

            // check if user is authenticated
            if (String.IsNullOrWhiteSpace(userId))
            {
                return RedirectToPage("/Identity/Account/Login");
            }

            // get user watchlist
            IEnumerable<WatchlistViewModel> model = await watchlistService.GetUserWatchListByUserIdAsync(userId);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddToWatchlist(string movieId)
        {
            string userId = this.userManager.GetUserId(User)!;
            if (String.IsNullOrWhiteSpace(userId))
            {
                return RedirectToPage("/Identity/Account/Login");
            }

            bool result = await this.watchlistService
                .AddMovieToUserWatchListAsync(movieId, userId);
            if (result == false)
            {
                TempData[nameof(AddToWatchListNotSuccessfulMessage)] = AddToWatchListNotSuccessfulMessage; // if the redirect was to an action of the same controller, ViewData["ErrorMessage"] = "..."; would have been enough]
                return RedirectToAction("Index", "Movie");
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromWatchlist(string movieId)
        {
            string userId = this.userManager.GetUserId(User)!;
            if (String.IsNullOrWhiteSpace(userId))
            {
                return this.RedirectToPage("/Identity/Account/Login");
            }

            bool result = await this.watchlistService
                .RemoveMovieFromUserWatchListAsync(movieId, userId);
            if (result == false)
            {
                TempData[nameof(AddToWatchListNotSuccessfulMessage)] = AddToWatchListNotSuccessfulMessage;
                return this.RedirectToAction("Index", "Movie");
            }

            return RedirectToAction("Index");
        }
    }
}
