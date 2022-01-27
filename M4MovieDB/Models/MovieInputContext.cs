using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace M4MovieDB.Models
{
    public class MovieInputContext : DbContext
    {
        //Constructor
        public MovieInputContext(DbContextOptions<MovieInputContext> options) : base (options)
        {
            // left blank for now
        }
        // create set of data
        public DbSet<Movie> responses { get; set; }

        // seed new movies
        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Movie>().HasData(

                new Movie
                {
                    MovieId = 1,
                    Category = "Comedy",
                    Title = "Meet the Parent",
                    Year = 2000,
                    Director = "Jay Roach",
                    Rating = "PG",
                    Edited = false,
                    LentTo = "Rosa",
                    Notes = "Funnies movie I own"
                },

                new Movie
                {
                    MovieId = 2,
                    Category = "Action",
                    Title = "Avergers",
                    Year = 2012,
                    Director = "Anthony Russo",
                    Rating = "PG-13",
                    Edited = false,
                    LentTo = "Jimmy",
                    Notes = "None"
                },

                new Movie
                {
                    MovieId = 3,
                    Category = "Documentary",
                    Title = "Free Solo",
                    Year = 2018,
                    Director = " Jimmy Chin",
                    Rating = "PG-13",
                    Edited = false,
                    LentTo = "NoOne",
                    Notes = "Free Climbing"
                }
            );
        }
    }
}
