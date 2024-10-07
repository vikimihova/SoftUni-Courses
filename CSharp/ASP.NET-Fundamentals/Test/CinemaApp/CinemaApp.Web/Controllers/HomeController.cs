using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CinemaApp.Web.ViewModels;

namespace CinemaApp.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.Title = "Home Page";
            ViewBag.Message = "Welcome to the Cinema Web App!";

            return View();
        }
    }
}
