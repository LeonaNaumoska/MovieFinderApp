using EMovieFinder.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMovieFinder.Domain.DomainModels
{
    public class MovieCart : BaseEntity
    {
        public string OwnerId { get; set; }
        public EMovieAppUser Owner { get; set; }
        public virtual ICollection<MovieInMovieCart> MoviesInMovieCart { get; set; } 

        public MovieCart() { }
    }
}
