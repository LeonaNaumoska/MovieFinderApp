using EMovieFinder.Domain.DomainModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMovieFinder.Domain.Identity
{
    public class EMovieAppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Adress { get; set; }
        public int MembershipType { get; set; }

        public virtual MovieCart UserCart { get; set; }
        public virtual EMovieAppUser MovieUser { get; set; }
    }
}
