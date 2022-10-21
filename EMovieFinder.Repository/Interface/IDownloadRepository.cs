using EMovieFinder.Domain.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMovieFinder.Repository.Interface
{
    public interface IDownloadRepository
    {
        List<Download> getAllDownloads();
        Download getDownloadDetails(BaseEntity model);
    }
}
