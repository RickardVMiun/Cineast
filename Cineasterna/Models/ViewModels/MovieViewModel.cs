using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cineasterna.Models
{
    public class MovieViewModel
    {
        public GetMoviesOmdbDTO Movie { get; set; }

        public MovieViewModel(GetMoviesOmdbDTO movie)
        {
            Movie = movie;
        }
    }
}
