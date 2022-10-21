using EMovieFinder.Domain.DomainModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EMovieFinder.Domain.DomainModels
{
    public class Movie : BaseEntity
    {
        [Required]
        public string MovieName { get; set; }
        [Required]
        public string MovieImage { get; set; }
        [Required]
        public string MovieCategory { get; set; }
        
        [Required]
        public int Rating { get; set; }

        [Required]
        public string MovieDownloadLink { get; set; }

        public virtual ICollection<MovieInMovieCart> MoviesInMovieCart { get; set; }
        public virtual ICollection<MovieInDownload> Downloads { get; set; }

        public Movie() { }
    }
}
