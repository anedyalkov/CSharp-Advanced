namespace _04.Movie_Time
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var movies = new Dictionary<string, Dictionary<string, TimeSpan>>();
            var favouriteGenre = Console.ReadLine();
            var favouriteDuration = Console.ReadLine();

            string input;
            while ((input = Console.ReadLine()) != "POPCORN!")
            {
                var tokens = input.Split("|".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToArray();

                var movie = tokens[0];
                var genre = tokens[1];
                var durationElements = tokens[2];

                var durationParts = durationElements.Split(":").Select(int.Parse).ToArray();

                var hours = durationParts[0];
                var minutes = durationParts[1];
                var seconds = durationParts[2];
                var duration = new TimeSpan(hours, minutes, seconds);

                if (!movies.ContainsKey(genre))
                {
                    movies[genre] = new Dictionary<string, TimeSpan>();
                }

                movies[genre][movie] = duration;
            }
            
            if (favouriteDuration == "Short")
            {
                var selectedMovies = movies
                     .Where(x => x.Key == favouriteGenre)
                     .ToDictionary(x => x.Key,
                                   x => x.Value.OrderBy(y => y.Value)
                                   .ThenBy(y => y.Key)
                                   .ToDictionary(y => y.Key, y => y.Value));

                ChooseMovie(selectedMovies);
            }
            if (favouriteDuration == "Long")
            {
                var selectedMovies = movies
                     .Where(x => x.Key == favouriteGenre)
                     .ToDictionary(x => x.Key,
                                   x => x.Value.OrderByDescending(y => y.Value)
                                   .ThenBy(y => y.Key)
                                   .ToDictionary(y => y.Key, y => y.Value));
                ChooseMovie(selectedMovies);
            }
        
            TimeSpan totalPlaylistDuration = TimeSpan.Zero;
            foreach (var item in movies)
            {
                foreach (var kvp in item.Value)
                {
                    var movie = kvp.Key;
                    var duration = kvp.Value;
                    totalPlaylistDuration += duration;
                }
            }
            Console.WriteLine($"Total Playlist Duration: {totalPlaylistDuration.ToString()}");
        }

        private static void ChooseMovie(Dictionary<string, Dictionary<string, TimeSpan>> selectedMovies)
        {
            foreach (var item in selectedMovies)
            {
                foreach (var kvp in item.Value)
                {
                    var movie = kvp.Key;
                    var duration = kvp.Value;
                    Console.WriteLine(movie);
                    string secondInput = Console.ReadLine();
                    if (secondInput == "Yes")
                    {
                        Console.WriteLine($"We're watching {movie} - {duration.ToString()}");
                        break;
                    }
                }
            }
        }
    }
}

