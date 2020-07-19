using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcMovie.Data;
using System;
using System.Linq;

namespace MvcMovie.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcMovieContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MvcMovieContext>>()))
            {
                // Look for any movies.
                if (context.Movie.Any())
                {
                    return;   // DB has been seeded
                }

                context.Movie.AddRange(
                    new Movie
                    {
                        Title = "Meet The Mormons",
                        ReleaseDate = DateTime.Parse("2014-2-12"),
                        GenreId = 1,
                        Rating = "PG",
                        Price = 7.99M
                    },

                    new Movie
                    {
                        Title = "The Saratov Approach ",
                        ReleaseDate = DateTime.Parse("2013-3-13"),
                        Rating = "PG",
                        GenreId = 2,
                        Price = 8.99M
                    },

                    new Movie
                    {
                        Title = "17 Miracles",
                        ReleaseDate = DateTime.Parse("2011-2-23"),
                        Rating = "G",
                        GenreId = 2,
                        Price = 9.99M
                    },

                    new Movie
                    {
                        Title = "The Other Side of Heaven",
                        ReleaseDate = DateTime.Parse("2001-4-15"),
                        Rating = "PG",
                        GenreId = 2,
                        Price = 3.99M
                    }
                );
                context.SaveChanges();
            }
        }
    }
}