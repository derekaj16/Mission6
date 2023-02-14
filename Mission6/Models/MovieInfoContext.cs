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
    }
}
