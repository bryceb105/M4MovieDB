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
        public DbSet<Category> Category { get; set; }

        // seed new movies
        protected override void OnModelCreating(ModelBuilder mb)
        //set category ID's = Categories
        {
            mb.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Action/Adventure" },
                new Category { CategoryId = 2, CategoryName = "Comedy" },
                new Category { CategoryId = 3, CategoryName = "Drama" },
                new Category { CategoryId = 4, CategoryName = "Family" },
                new Category { CategoryId = 5, CategoryName = "Horror/Suspense" },
                new Category { CategoryId = 6, CategoryName = "Miscellaneous" },
                new Category { CategoryId = 7, CategoryName = "Television" },
                new Category { CategoryId = 8, CategoryName = "VHS" }
                );

            mb.Entity<Movie>().HasData(

                new Movie
                {
                    MovieId = 1,
                    CategoryId = 2,
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
                    CategoryId = 1,
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
                    CategoryId = 6,
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
