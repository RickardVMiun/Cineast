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
            var allMoviesFromCMDB = await repository.GetMovies();
            var toplistFromCMDB = await repository.GetTopList();

            //Skapa upp lista med filmer från CMDb-api:et
            foreach (var item in toplistFromCMDB)
            {
                GetMoviesDto.Add(item);
            }

            //Populera imdbList med filmerna som finns i CMDb's arkiv, fast med kompletterande information från OMDb.
            for (int i = 0; i < GetMoviesDto.Count; i++)
            {
                var model2 = await repository.GetMoviesOmdb(GetMoviesDto[i].imdbID);
                imdbList.Add(model2);
            }


            //Skapa en ny lista baserat på TopMovieDTO's som har både GetMoviesDTO och GetMoviesOMDBDto som properties.
            List<TopMovieDto> Topmovies = new List<TopMovieDto>();

            for (int i = 0; i < imdbList.Count; i++)
            {
                var modell = new TopMovieDto();
                modell.getMoviesOmdbDTO = imdbList[i];
                modell.getMoviesDto = GetMoviesDto[i];
                Topmovies.Add(modell);
            }

            return View(Topmovies);
        }
        public IActionResult Movie()
        {
            return View();
        }
    }
}
