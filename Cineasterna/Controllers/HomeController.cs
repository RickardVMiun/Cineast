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
            var model = await repository.GetMovies();
            var model2 = await repository.GetMoviesOmdb();
            return View(model);
        }

        public IActionResult Browse()
        {
            return View();
        }

        public IActionResult Movie()
        {
            return View();
        }
 
    }
}
