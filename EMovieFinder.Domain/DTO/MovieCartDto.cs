using EMovieFinder.Domain.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMovieFinder.Domain.DTO
{
    public class MovieCartDto
    {
        public List<MovieInMovieCart> MovieInMovieCarts { get; set; } 
        //public int TotalMovie { get; set; }
    }
}
