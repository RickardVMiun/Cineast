using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cineasterna.Models
{
    public class TopMovieDto
    {
        public GetMoviesDto getMoviesDto { get; set; }
        public GetMoviesOmdbDTO getMoviesOmdbDTO { get; set; }
    }
}