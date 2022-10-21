using EMovieFinder.Domain.DomainModels;
using EMovieFinder.Domain.DTO;
using EMovieFinder.Repository.Interface;
using EMovieFinder.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EMovieFinder.Service.Implementation
{
    public class MovieCartService : IMovieCartService
    {
        private readonly IRepository<MovieCart> _movieCartRepositorty;
        private readonly IRepository<MovieInDownload> _movieInDownloadRepositorty;
        private readonly IRepository<Download> _downloadRepositorty;
        private readonly IUserRepository _userRepository;

        public MovieCartService(IRepository<MovieCart> movieCartRepositorty, IRepository<MovieInDownload> movieInDownloadRepositorty, IRepository<Download> downloadRepositorty, IUserRepository userRepository)
        {
            _movieCartRepositorty = movieCartRepositorty;
            _userRepository = userRepository;
            _movieInDownloadRepositorty = movieInDownloadRepositorty;
            _downloadRepositorty = downloadRepositorty;
        }

        public bool deleteMovieFromMovieCart(string userId, Guid id)
        {
            if (!string.IsNullOrEmpty(userId) && id != null)
            {

                var loggedInUser = this._userRepository.Get(userId);

                var userMovieCart = loggedInUser.UserCart;

                var itemToDelete = userMovieCart.MoviesInMovieCart.Where(z => z.MovieId.Equals(id)).FirstOrDefault();

                userMovieCart.MoviesInMovieCart.Remove(itemToDelete);

                this._movieCartRepositorty.Update(userMovieCart);

                return true;
            }

            return false;
        }

        public MovieCartDto getMovieCartInfo(string userId)
        {
            var loggedInUser = this._userRepository.Get(userId);

            var userMovieCart = loggedInUser.UserCart;

            var AllMovies = userMovieCart.MoviesInMovieCart.ToList();

            var allMovieForDownload = AllMovies.Select(z => new
            {
                Quanitity = z.Quantity
            }).ToList();

            //var totalMovies = 0;

            //foreach (var item in allMovieForDownload)
            //{
            //    totalMovies += item.Quanitity;
            //}

            MovieCartDto scDto = new MovieCartDto
            {
                MovieInMovieCarts = AllMovies
                //TotalPrice = totalMovies
            };

            return scDto;
        }

        public bool downloadNow(string userId)
        {
            if (!string.IsNullOrEmpty(userId))
            {

                var loggedInUser = this._userRepository.Get(userId);

                var userMovieCart = loggedInUser.UserCart;

                Download order = new Download
                {
                    Id = Guid.NewGuid(),
                    User = loggedInUser,
                    UserId = userId
                };

                this._downloadRepositorty.Insert(order);

                List<MovieInDownload> moviesInDownloads = new List<MovieInDownload>();

                var result = userMovieCart.MoviesInMovieCart.Select(z => new MovieInDownload
                {
                    Id = Guid.NewGuid(),
                    MovieId = z.Movie.Id,
                    DownloadedMovie = z.Movie,
                    DownloadId = order.Id,
                    UserDownload = order
                }).ToList();

                moviesInDownloads.AddRange(result);

                foreach (var item in moviesInDownloads)
                {
                    this._movieInDownloadRepositorty.Insert(item);
                }

                loggedInUser.UserCart.MoviesInMovieCart.Clear();

                this._userRepository.Update(loggedInUser);

                return true;
            }
            return false;
        }
    }
}
