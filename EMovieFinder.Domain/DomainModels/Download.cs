using EMovieFinder.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMovieFinder.Domain.DomainModels
{
    public class Download : BaseEntity
    {
        public string UserId { get; set; }
        public EMovieAppUser User { get; set; }

        public virtual ICollection<MovieInDownload> Movies { get; set; }

    }
}
