using Microsoft.EntityFrameworkCore;
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

        public DbSet<MovieModel> movies { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<MovieModel>().HasData(
               new MovieModel
               {
                   MovieId = 1,
                   Category = "Action/Adventure",
                   Title = "The Avengers",
                   Year = 2012,
                   DirectorName = "Joss Whedon",
                   Rating = "PG-13"
               },
               new MovieModel
               {
                   MovieId = 2,
                   Category = "Action/Adventure",
                   Title = "Batman",
                   Year = 1989,
                   DirectorName = "Tim Burton",
                   Rating = "PG-13"
               },
               new MovieModel
               {
                   MovieId = 3,
                   Category = "Action/Adventure",
                   Title = "The Dark Knight",
                   Year = 2008,
                   DirectorName = "Christopher Nolan",
                   Rating = "PG-13"
               }
            );
        }
    }
}
