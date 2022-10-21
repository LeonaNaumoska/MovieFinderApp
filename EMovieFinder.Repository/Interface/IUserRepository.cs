using EMovieFinder.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMovieFinder.Repository.Interface
{
    public interface IUserRepository
    {
        IEnumerable<EMovieAppUser> GetAll();
        EMovieAppUser Get(string id);
        void Insert(EMovieAppUser entity);
        void Update(EMovieAppUser entity);
        void Delete(EMovieAppUser entity);
        EMovieAppUser GetMemPrice(string id);
    }
}
