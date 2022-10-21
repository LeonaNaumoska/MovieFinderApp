using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMovieFinder.Domain.DomainModels
{
    public class MovieInMovieCart : BaseEntity
    {
        public Guid MovieId { get; set; }
        public Movie Movie { get; set; }
        public Guid MovieCartId { get; set; }
        public MovieCart MovieCart { get; set; }

        public int Quantity { get; set; }

       
    }
}
