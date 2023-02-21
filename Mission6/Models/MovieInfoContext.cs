using Microsoft.EntityFrameworkCore;
using Mission6.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission6.Models
{
    public class MovieInfoContext : DbContext
    {
        public MovieInfoContext(DbContextOptions<MovieInfoContext> options) : base (options)
        {

        }

        // Get databases
        public DbSet<Movie> movies { get; set; }
        public DbSet<Category> categories { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            // Seeding database with initial data
            mb.Entity<Category>().HasData(
                new Category
                {
                    CategoryID = 1,
                    CategoryName = "Action/Adventure"
                },
                new Category
                {
                    CategoryID = 2,
                    CategoryName = "Comedy"
                },
                new Category
                {
                    CategoryID = 3,
                    CategoryName = "Drama"
                },
                new Category
                {
                    CategoryID = 4,
                    CategoryName = "Family"
                },
                new Category
                {
                    CategoryID = 5,
                    CategoryName = "Horror/Suspense"
                },
                new Category
                {
                    CategoryID = 6,
                    CategoryName = "Miscellaneous"
                },
                new Category
                {
                    CategoryID = 7,
                    CategoryName = "Television"
                },
                new Category
                {
                    CategoryID = 8,
                    CategoryName = "VHS"
                }

            );

            mb.Entity<Movie>().HasData(
               new Movie
               {
                   MovieId = 1,
                   CategoryID = 1,
                   Title = "The Avengers",
                   Year = 2012,
                   DirectorName = "Joss Whedon",
                   Rating = "PG-13"
               },
               new Movie
               {
                   MovieId = 2,
                   CategoryID = 1,
                   Title = "Batman",
                   Year = 1989,
                   DirectorName = "Tim Burton",
                   Rating = "PG-13"
               },
               new Movie
               {
                   MovieId = 3,
                   CategoryID = 1,
                   Title = "The Dark Knight",
                   Year = 2008,
                   DirectorName = "Christopher Nolan",
                   Rating = "PG-13"
               }
            );
        }
    }
}
