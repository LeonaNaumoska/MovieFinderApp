using EMovieFinder.Domain.Identity;
using EMovieFinder.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EMovieFinder.Repository.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext context;
        private DbSet<EMovieAppUser> entities;
        string errorMessage = string.Empty;

        public UserRepository(ApplicationDbContext context)
        {
            this.context = context;
            entities = context.Set<EMovieAppUser>();
        }

        public IEnumerable<EMovieAppUser> GetAll()
        {
            return entities.AsEnumerable();
        }

        public EMovieAppUser Get(string id)
        {
            return entities
                .Include(z => z.UserCart)
                .Include("UserCart.MoviesInMovieCart")
                .Include("UserCart.MoviesInMovieCart.Movie")
                .SingleOrDefault(s => s.Id == id);
        }

        public EMovieAppUser GetMemPrice(string id)
        {
            return entities
                .Include(z => z.MovieUser)
                .Include("MovieUser.MembershipType")
                .SingleOrDefault(s => s.Id == id);
        }

        public void Insert(EMovieAppUser entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            context.SaveChanges();
        }

        public void Update(EMovieAppUser entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Update(entity);
            context.SaveChanges();
        }

        public void Delete(EMovieAppUser entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            context.SaveChanges();
        }
    }
}
