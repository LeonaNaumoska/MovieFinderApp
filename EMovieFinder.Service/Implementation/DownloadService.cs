using EMovieFinder.Domain.DomainModels;
using EMovieFinder.Repository.Interface;
using EMovieFinder.Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMovieFinder.Service.Implementation
{
    public class DownloadService : IDownloadService
    {
        private readonly IDownloadRepository _downloadRepository;
        public DownloadService(IDownloadRepository downloadRepository)
        {
            this._downloadRepository = downloadRepository;
        }

        public List<Download> getAllDownloads()
        {
            return this._downloadRepository.getAllDownloads();
        }

        public Download getDownloadDetails(BaseEntity model)
        {
            return this._downloadRepository.getDownloadDetails(model);
        }
    }
}
