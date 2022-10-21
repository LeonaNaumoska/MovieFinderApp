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
    public class MovieService : IMovieService
    {
        private readonly IRepository<Movie> _movieRepository;
        private readonly IRepository<MovieInMovieCart> _movieInMovieCartRepository;
        private readonly IUserRepository _userRepository;
        public MovieService(IRepository<Movie> movieRepository, IRepository<MovieInMovieCart> movieInMovieCartRepository, IUserRepository userRepository)
        {
            _movieRepository = movieRepository;
            _userRepository = userRepository;
            _movieInMovieCartRepository = movieInMovieCartRepository;
        }

        public bool AddToMovieCart(AddToMovieCartDto item, string userID)
        {

            var user = this._userRepository.Get(userID);

            var userMovieCart = user.UserCart;

            if (item.MovieId != null && userMovieCart != null)
            {
                var movie = this.GetDetailsForMovie(item.MovieId);

                if (movie != null)
                {
                    MovieInMovieCart itemToAdd = new MovieInMovieCart
                    {
                        Movie = movie,
                        MovieId = movie.Id,
                        MovieCart = userMovieCart,
                        MovieCartId = userMovieCart.Id,
                        Quantity = item.Quantity
                    };

                    this._movieInMovieCartRepository.Insert(itemToAdd);
                    return true;
                }
                return false;
            }
            return false;
        }

        public void CreateNewMovie(Movie m)
        {
            this._movieRepository.Insert(m);
        }

        public void DeleteMovie(Guid id)
        {
            var movie = this.GetDetailsForMovie(id);
            this._movieRepository.Delete(movie);
        }

        public List<Movie> GetAllMovies()
        {
            return this._movieRepository.GetAll().ToList();
        }

        public Movie GetDetailsForMovie(Guid? id)
        {
            return this._movieRepository.Get(id);
        }

        public AddToMovieCartDto GetMovieCartInfo(Guid? id)
        {
            var movie = this.GetDetailsForMovie(id);
            AddToMovieCartDto model = new AddToMovieCartDto
            {
                SelectedMovie = movie,
                MovieId = movie.Id,
                Quantity = 1
            };

            return model;
        }

        public void UpdeteExistingMovie(Movie m)
        {
            this._movieRepository.Update(m);
        }
    }
}
