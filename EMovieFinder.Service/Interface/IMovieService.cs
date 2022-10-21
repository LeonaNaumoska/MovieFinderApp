using EMovieFinder.Domain.DomainModels;
using EMovieFinder.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMovieFinder.Service.Interface
{
    public interface IMovieService
    {
        List<Movie> GetAllMovies(); 
        Movie GetDetailsForMovie(Guid? id); 
        void CreateNewMovie(Movie m); 
        void UpdeteExistingMovie(Movie m); 
        AddToMovieCartDto GetMovieCartInfo(Guid? id); 
        void DeleteMovie(Guid id); 
        bool AddToMovieCart(AddToMovieCartDto item, string userID); 
    }
}
