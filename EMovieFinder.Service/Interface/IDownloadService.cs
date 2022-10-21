using EMovieFinder.Domain.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMovieFinder.Service.Interface
{
    public interface IDownloadService
    {
        List<Download> getAllDownloads();
        Download getDownloadDetails(BaseEntity model);
    }
}
