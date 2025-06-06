﻿using CinemaApp.Data;
using CinemaApp.Data.Models;
using CinemaApp.Web.ViewModels.Cinema;
using CinemaApp.Web.ViewModels.Movie;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CinemaApp.Web.Controllers
{
    public class CinemaController : Controller
    {
        private readonly CinemaDbContext dbContext;

        public CinemaController(CinemaDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<CinemaIndexViewModel> cinemas = this.dbContext.Cinemas
                .Select(c => new CinemaIndexViewModel()
                {
                    Id = c.Id.ToString(),
                    Name = c.Name,
                    Location = c.Location,
                })
                .ToArray();

            return View(cinemas);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CinemaCreateFormModel model)
        {
            if (!ModelState.IsValid) 
            {
                return View(model);
            }

            Cinema newCinema = new Cinema()
            {
                Name = model.Name,
                Location = model.Location,
            };

            this.dbContext.Cinemas.Add(newCinema);
            this.dbContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Details(string id)
        {            
            //if (String.IsNullOrWhiteSpace(id))
            //{
            //    return RedirectToAction(nameof(Index));
            //}

            //bool isIdValid = Guid.TryParse(id, out Guid idGuid);

            //if (!isIdValid)
            //{
            //    return RedirectToAction(nameof(Index));
            //}

            Cinema cinema = dbContext.Cinemas.FirstOrDefault(c => c.Id.ToString() == id);

            if (cinema == null)
            {
                return RedirectToAction(nameof(Index));
            }            

            var model = new CinemaDetailsViewModel()
                {
                    Name = cinema.Name,
                    Location = cinema.Location,
                    Movies = cinema.CinemaMovies
                        .Select(cm => new MovieCinemaViewModel()
                        {
                            Title = cm.Movie.Title,
                            Duration = cm.Movie.Duration,
                        })
                        .ToArray()
                };

            return View(model);
        }

    }
}
