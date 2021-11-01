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


        // Populerar förstasidan med den aktuella toplistan från CMDb.
        public async Task<IActionResult> Index()
        {
            var toplistFromCMDB = await repository.GetTopList();
            var moviesFromOMDB = await repository.GetMoviesOmdb(toplistFromCMDB);

            HomeViewModel homeViewModel = new HomeViewModel(moviesFromOMDB, toplistFromCMDB);
            
            return View(homeViewModel);
         }
    }
}
