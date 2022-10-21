using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMovieFinder.Domain.DomainModels
{
    public class MovieInDownload : BaseEntity
    {
        public Guid MovieId { get; set; }
        public Movie DownloadedMovie { get; set; }
        public Guid DownloadId { get; set; }
        public Download UserDownload { get; set; }
        public int Quantity { get; set; }
    }
}
