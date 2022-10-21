using EMovieFinder.Domain.DomainModels;
using EMovieFinder.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMovieFinder.Repository.Implementation
{
    public class DownloadRepository : IDownloadRepository
    {
        private readonly ApplicationDbContext _context;
        private DbSet<Download> entities;
        string errorMessage = string.Empty;

        public DownloadRepository(ApplicationDbContext context)
        {
            this._context = context;
            entities = context.Set<Download>();
        }

        public List<Download> getAllDownloads()
        {
            return entities
                .Include(z => z.User)
                .Include(z => z.Movies)
                .Include("MovieInDownload.DownloadedMovie")
                .ToListAsync().Result;
        }

        public Download getDownloadDetails(BaseEntity model)
        {
             return entities
                .Include(z => z.User)
                .Include(z => z.Movies)
                .Include("MovieInDownload.DownloadedMovie")
                .SingleOrDefaultAsync(z => z.Id == model.Id).Result;
        }
    }
}
