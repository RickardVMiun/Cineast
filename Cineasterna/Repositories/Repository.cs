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

        public Repository(IApiClient apiClient)
        {
            this.apiClient = apiClient;
        }
        public async Task<GetMoviesDto[]> GetMovies()
        {
            var result = await apiClient.GetAsync<GetMoviesDto[]>($"{baseEndpoint}/movie");
            return result;
        }
    }
}
