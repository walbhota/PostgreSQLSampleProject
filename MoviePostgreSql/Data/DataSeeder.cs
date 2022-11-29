using MoviePostgreSql.Domain;

namespace MoviePostgreSql.Data
{
    public static class DataSeeder
    {
        public static void Seed(this IHost host)
        {
            using var scope = host.Services.CreateScope();
            using var context = scope.ServiceProvider.GetRequiredService<MovieDataContext>();
            context.Database.EnsureCreated();
            AddMovies(context);
        }

        private static void AddMovies(MovieDataContext context)
        {
            var movie = context.Movies.FirstOrDefault();
            if (movie != null) return;

            context.Movies.Add(new Movie
            {
                Title = "The Shawshank Redemption",
                Year = 1994,
                Summary = "Chronicles the experiences of a formerly successful banker as a prisoner in the gloomy jailhouse of Shawshank after being found guilty of a crime he did not commit.",
                Actors = new List<Actor>
                {
                    new Actor{FullName = "Morgan Freeman"},
                    new Actor{FullName = "Tim Robbins"}
                }
            });

            context.Movies.Add(new Movie
            {
                Title = "Instellar",
                Year = 2014,
                Summary = "A team of explorers travel through a wormhole in space in an attempt to ensure humanity's survival.",
                Actors = new List<Actor>
                {
                    new Actor{FullName = "Matthew McConaughey"},
                    new Actor{FullName = "Anne Hathaway"},
                    new Actor{FullName = "Jessica Chastain"}
                }
            });

            context.Movies.Add(new Movie
            {
                Title = "Tenet",
                Year = 2020,
                Summary = "follows a secret agent who learns to manipulate the flow of time to prevent an attack from the future that threatens to annihilate the present world.",
                Actors = new List<Actor>
                {
                    new Actor{FullName = "John David Washington"},
                    new Actor{FullName = "Robert Pattinson "}
                }
            });

            context.SaveChanges();
        }
    }
}
