using Cineasterna.Infrastructure;
using Cineasterna.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cineasterna.Repositories
{
    public class Repository : IRepository
    {
        private readonly IApiClient apiClient;
        private readonly string baseEndpoint = "https://grupp9.dsvkurs.miun.se/api";
        private readonly string baseEndpoint2 = "http://www.omdbapi.com/?apikey=b040ce7c&";

        public Repository(IApiClient apiClient)
        {
            this.apiClient = apiClient;
        }

        //Hämta alla filmer i CMDB
        public async Task<List<GetMoviesDto>> GetMovies()
        {
            var movies = await apiClient.GetAsync<List<GetMoviesDto>>($"{baseEndpoint}/movie");
            return movies;
        }

        public async Task<List<GetMoviesDto>> GetTopList() => await apiClient.GetAsync<List<GetMoviesDto>>($"{baseEndpoint}/toplist");

        // Hämta alla filmer från OMDB som finns i CMDB's databas
        public async Task<List<GetMoviesOmdbDTO>> GetMoviesOmdb(IEnumerable<GetMoviesDto> moviesFromCmdb)
        {
            var imdbList = new List<GetMoviesOmdbDTO>();
            var tasks = new List<Task<GetMoviesOmdbDTO>>();
            // Loopa igenom våran lista och hämta information om filmen från OMDB
            for (int i = 0; i < moviesFromCmdb.Count(); i++)
            {
                // Get movie from OMDB
                var movie = apiClient.GetAsync<GetMoviesOmdbDTO>($"{baseEndpoint2}&i={moviesFromCmdb.ElementAt(i).imdbID}");
                // Lägger vi den i en lista
                //var model2 = await repository.GetMoviesOmdb(GetMoviesDto[i].imdbID);
                tasks.Add(movie);
            }
            // När alla filmer är hämtade
            await Task.WhenAll(tasks);
            // Lägger alla filmer i en lista
            for (int i = 0; i < tasks.Count; i++)
            {
                imdbList.Add(tasks[i].Result);
            }

            return imdbList;
        }

        // Hämta ut vald film med en längre plot
        public async Task<GetMoviesOmdbDTO> GetLongPlot(string imdbID) => await apiClient.GetAsync<GetMoviesOmdbDTO>($"{baseEndpoint2}&i={imdbID}&plot=full");
        
        // Hämta film beroende på titel
        public async Task<GetMoviesOmdbDTO> GetMovieByTitle(string title) => await apiClient.GetAsync<GetMoviesOmdbDTO>($"{baseEndpoint2}&t={title}");
        
    }
}
