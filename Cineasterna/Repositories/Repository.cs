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
        private readonly string baseEndpoint2 = "http://www.omdbapi.com/?i=tt0120338&apikey=b040ce7c";

        public Repository(IApiClient apiClient)
        {
            this.apiClient = apiClient;
        }
        public async Task<GetMoviesDto[]> GetMovies()
        {
            var result = await apiClient.GetAsync<GetMoviesDto[]>($"{baseEndpoint}/movie");
            return result;
        }

        public async Task<GetMoviesOmdbDTO> GetMoviesOmdb()
        {
            var result = await apiClient.GetAsync<GetMoviesOmdbDTO>(baseEndpoint2);
            return result;
        }
    }
}
