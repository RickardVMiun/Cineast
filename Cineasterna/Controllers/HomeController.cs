using Cineasterna.Models;
using Cineasterna.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Cineasterna.Controllers
{
    public class HomeController : Controller
    {
        private IRepository repository;
        public HomeController(IRepository repository)
        {
            this.repository = repository;
        }
        public async Task<IActionResult> Index()
        {
            var toplistFromCMDB = await repository.GetTopList();
            var moviesFromOMDB = await repository.GetMoviesOmdb(toplistFromCMDB);

            HomeViewModel homeViewModel = new HomeViewModel(moviesFromOMDB, toplistFromCMDB);
            
            return View(homeViewModel);
        }
        public IActionResult Movie()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> FetchMovie(SearchViewModel model)
        {
            var searchedMovie = await repository.GetMovieByTitle(model.Query);

            MovieViewModel movieViewModel = new MovieViewModel(searchedMovie);
            return View("~/Views/Home/Movie.cshtml", movieViewModel);
        }
    }
}
