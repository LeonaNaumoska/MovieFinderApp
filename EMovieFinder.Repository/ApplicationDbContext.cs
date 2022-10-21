using EMovieFinder.Domain.DomainModels;
using EMovieFinder.Domain.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace EMovieFinder.Repository
{
    public class ApplicationDbContext : IdentityDbContext<EMovieAppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Movie> Movie { get; set; }
        public virtual DbSet<MovieCart> MovieCarts { get; set; }
        public virtual DbSet<MovieInMovieCart> MoviesInMovieCart { get; set; }
        public virtual DbSet<MovieInDownload> MovieInDownloads { get; set; }
        public virtual DbSet<Download> Downloads { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Movie>()
               .Property(z => z.Id)
               .ValueGeneratedOnAdd();

            builder.Entity<MovieCart>()
                .Property(z => z.Id)
                .ValueGeneratedOnAdd();

            //manyToMany relacijata
            builder.Entity<MovieInMovieCart>()
                .HasKey(z => new { z.MovieId, z.MovieCartId });

            builder.Entity<MovieInMovieCart>()
                .HasOne(z => z.Movie)
                .WithMany(z => z.MoviesInMovieCart)
                .HasForeignKey(z => z.MovieCartId);

            builder.Entity<MovieInMovieCart>()
                .HasOne(z => z.MovieCart)
                .WithMany(z => z.MoviesInMovieCart)
                .HasForeignKey(z => z.MovieId);


            builder.Entity<MovieCart>()
                .HasOne<EMovieAppUser>(z => z.Owner)
                .WithOne(zt => zt.UserCart)
                .HasForeignKey<MovieCart>(bc => bc.OwnerId);


            //kompozitniot kluc
            builder.Entity<MovieInDownload>()
                .HasKey(z => new { z.MovieId, z.DownloadId });

            //konfiguracii za manyToMany relacijata
            builder.Entity<MovieInDownload>()
                .HasOne(z => z.DownloadedMovie)
                .WithMany(z => z.Downloads)
                .HasForeignKey(z => z.MovieId);


            builder.Entity<MovieInDownload>()
                .HasOne(z => z.UserDownload)
                .WithMany(zt => zt.Movies)
                .HasForeignKey(bc => bc.DownloadId);

        }
    }
}
