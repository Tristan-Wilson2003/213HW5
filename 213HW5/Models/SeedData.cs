using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using _213HW5.Data;
using System;
using System.Linq;

namespace _213HW5.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new _213HW5Context(
                serviceProvider.GetRequiredService<
                    DbContextOptions<_213HW5Context>>()))
            {
                // Look for any movies.
                if (context.Music.Any())
                {
                    return;   // DB has been seeded
                }
                context.Music.AddRange(
                    new Music
                    {
                        Title = "Lil Baby",
                        ReleaseDate = DateTime.Parse("2017-2-12"),
                        Genre = "Rap",
                        Price = 17.99M
                    },
                    new Music
                    {
                        Title = "Snoop Dogg ",
                        ReleaseDate = DateTime.Parse("1984-3-13"),
                        Genre = "Rap",
                        Price = 18.99M
                    },
                    new Music
                    {
                        Title = "Taylor Swift",
                        ReleaseDate = DateTime.Parse("2010-2-23"),
                        Genre = "Pop",
                        Price = 19.99M
                    },
                    new Music
                    {
                        Title = "Luke Combs",
                        ReleaseDate = DateTime.Parse("2021-4-15"),
                        Genre = "Country",
                        Price = 13.99M
                    }
                );
                context.SaveChanges();
            }
        }

    }
}
