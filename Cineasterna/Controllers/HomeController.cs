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
            var GetMoviesDto = new List<GetMoviesDto>();
            var imdblist = new List<GetMoviesOmdbDTO>();
            var model = await repository.GetMovies();

            foreach (var item in model)
            {
                GetMoviesDto.Add(item);
            }

            for (int i = 0; i < GetMoviesDto.Count; i++)
            {
                var model2 = await repository.GetMoviesOmdb(GetMoviesDto[i].imdbID);
                imdblist.Add(model2);
            }



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
