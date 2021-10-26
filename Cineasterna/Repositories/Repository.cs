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
        public async Task<GetMoviesDto[]> GetMovies()
        {
            var result = await apiClient.GetAsync<GetMoviesDto[]>($"{baseEndpoint}/movie");
            return result;
        }

        public async Task <GetMoviesDto[]> GetTopList()
        {
            var result = await apiClient.GetAsync<GetMoviesDto[]>($"{baseEndpoint}/toplist");
            return result;
        }

        // Hämta alla filmer från OMDB som finns i CMDB's databas
        public async Task<GetMoviesOmdbDTO> GetMoviesOmdb(string imdbID)
        {
            var result = await apiClient.GetAsync<GetMoviesOmdbDTO>($"{baseEndpoint2}i={imdbID}");
            return result;
        }

        // Hämta ut vald film med en längre plot
        public async Task<GetMoviesOmdbDTO> GetLongPlot(string imdbID)
        {
            var result = await apiClient.GetAsync<GetMoviesOmdbDTO>($"{baseEndpoint2}&i={imdbID}&plot=full");
            return result;
        }
    }
}
