using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cineasterna.Models
{
    public class HomeViewModel
    {
        public List<GetMoviesOmdbDTO> MoviesFromOMDB { get; }

        public HomeViewModel(List<GetMoviesOmdbDTO> moviesFromOMDB, List<GetMoviesDto> topmovies)
        {
            MoviesFromOMDB = moviesFromOMDB;

            for (int i = 0; i < moviesFromOMDB.Count; i++)
            {
                for (int j = 0; j < moviesFromOMDB.Count; j++)
                {
                    if(moviesFromOMDB[i].imdbID == topmovies[j].imdbID)
                    {
                        moviesFromOMDB[i].numberOfDislikes = topmovies[j].numberOfDislikes;
                        moviesFromOMDB[i].numberOfLikes = topmovies[j].numberOfLikes;
                    }
                }
            }

            //Förkorta plot om x.plot är kortare än x bokstäver.

            for (int i = 0; i < moviesFromOMDB.Count; i++)
            {
                if (moviesFromOMDB[i].Plot.Length > 130)
                {
                    moviesFromOMDB[i].Longplot = moviesFromOMDB[i].Plot.Remove(130);
                }
            }

        }
    }
}
