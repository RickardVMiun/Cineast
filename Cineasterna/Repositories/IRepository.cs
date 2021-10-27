using Cineasterna.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cineasterna.Repositories
{
    public interface IRepository
    {

        /// <summary>
        /// Retrieves all movies from CMDB api.
        /// </summary>
        /// <returns></returns>
        Task<List<GetMoviesDto>> GetMovies();
        Task<List<GetMoviesDto>> GetTopList();
        Task<List<GetMoviesOmdbDTO>> GetMoviesOmdb(IEnumerable<GetMoviesDto> moviesFromCmdb);
        Task<GetMoviesOmdbDTO> GetLongPlot(string imdbID);
        Task<GetMoviesOmdbDTO> GetMovieByTitle(string imdbID);
    }
}
