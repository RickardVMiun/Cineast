using Cineasterna.Models;
using Cineasterna.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cineasterna.Controllers
{
    public class MovieController : Controller
    {

        private IRepository repository;

        public MovieController(IRepository repository)
        {
            this.repository = repository;
        }
        public IActionResult Movie()
        {
            return View();
        }

        [HttpPost]
        // Hämtar film som användaren skriver in i sökfunktionen och skickar in detta i en separat vy.
        public async Task<ActionResult> FetchMovie(SearchViewModel model)
        {
            var toplistFromCMDB = await repository.GetTopList();
            try
            {
                var searchedMovie = await repository.GetMovieByTitle(model.Query);
                MovieViewModel movieViewModel = new MovieViewModel(searchedMovie, toplistFromCMDB);
                return View("~/Views/Home/Movie.cshtml", movieViewModel);
            }
            catch (Exception)
            {
                return View("~/Views/Home/Error.cshtml");
            }
        }

        // Hämtar film som användaren klickar på i topplistan och skickar in detta i en separat vy.
        public async Task<ActionResult> FetchTopMovie(string imdbid)
        {
            var toplistFromCMDB = await repository.GetTopList();
            try
            {
                var searchedMovie = await repository.GetLongPlot(imdbid);
                MovieViewModel movieViewModel = new MovieViewModel(searchedMovie, toplistFromCMDB);
                return View("~/Views/Home/Movie.cshtml", movieViewModel);
            }
            catch (Exception)
            {
                return View("~/Views/Home/Error.cshtml");
            }
        }
    }
}
