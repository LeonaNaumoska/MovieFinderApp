using EMovieFinder.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMovieFinder.Service.Interface
{
    public interface IMovieCartService
    {
        MovieCartDto getMovieCartInfo(string userId);
        bool deleteMovieFromMovieCart(string userId, Guid id);
        bool downloadNow(string userId);
    }
}
