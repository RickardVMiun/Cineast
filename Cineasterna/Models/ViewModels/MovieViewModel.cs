using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cineasterna.Models
{
    public class MovieViewModel
    {
        public GetMoviesOmdbDTO Movie { get; set; }

        public MovieViewModel(GetMoviesOmdbDTO movie, List<GetMoviesDto> topmovies)
        {
            Movie = movie;
            for (int i = 0; i < topmovies.Count; i++)
            {
                if (topmovies[i].imdbID == movie.imdbID)
                {
                    movie.numberOfLikes = topmovies[i].numberOfLikes;
                    movie.numberOfDislikes = topmovies[i].numberOfDislikes;
                }
            }
            if (movie.Ratings[0] == null)
            {
                movie.Ratings[0].Source = "Internet Movie Database";
                movie.Ratings[0].Value = "No score registered on IMDb";
            }
        }
    }
}
