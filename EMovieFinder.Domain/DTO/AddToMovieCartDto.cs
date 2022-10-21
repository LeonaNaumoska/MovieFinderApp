using EMovieFinder.Domain.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMovieFinder.Domain.DTO
{
    public class AddToMovieCartDto
    {
        public Movie SelectedMovie { get; set; }
        public Guid MovieId { get; set; }
        public int Quantity = 1;
    }
}
