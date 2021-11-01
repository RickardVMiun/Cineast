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

        /// <summary>
        /// Retrieves toplist from from CMDB api.
        /// </summary>
        /// <returns></returns>
        Task<List<GetMoviesDto>> GetTopList();

        Task<List<GetMoviesOmdbDTO>> GetMoviesOmdb(IEnumerable<GetMoviesDto> moviesFromCmdb);

        /// <summary>
        /// Retrieves movie with long plot based on imdbID from OMDb
        /// </summary>
        /// <returns></returns>
        Task<GetMoviesOmdbDTO> GetLongPlot(string imdbID);


        /// <summary>
        /// Retrieves movie from OMDb based on title.
        /// </summary>
        /// <returns></returns>
        Task<GetMoviesOmdbDTO> GetMovieByTitle(string imdbID);
    }
}
