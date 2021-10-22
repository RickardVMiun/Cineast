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
            // Ta reda på vilken film som har högst antal upvotes

            var GetMoviesDto = new List<GetMoviesDto>();
            var imdbList = new List<GetMoviesOmdbDTO>();
            var copyObjectWithMostUpvotes = new List<GetMoviesOmdbDTO>();
            var model = await repository.GetMovies();

            foreach (var item in model)
            {
                GetMoviesDto.Add(item);
            }

            for (int i = 0; i < GetMoviesDto.Count; i++)
            {
                var model2 = await repository.GetMoviesOmdb(GetMoviesDto[i].imdbID);
                imdbList.Add(model2);
            }
            var item2 = GetMoviesDto.Max(x => x.numberOfLikes);
            var mostUpvotedMovie = GetMoviesDto.First(x => x.numberOfLikes == item2);

            // Objekt med den högst rankade filmen i cMDB.
            copyObjectWithMostUpvotes.Add(imdbList.First(x => x.imdbID == mostUpvotedMovie.imdbID));
            return View(copyObjectWithMostUpvotes);
        }

        public async  Task<IActionResult> Browse()
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
            return View(imdblist);
        }

        public IActionResult Movie()
        {
            return View();
        }
 
    }
}
