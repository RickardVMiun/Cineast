using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cineasterna.Models
{
    public class GetMoviesDto
    {
        public string imdbID { get; set; }
        public int numberOfLikes { get; set; }
        public int numberOfDislikes { get; set; }
    }
}
