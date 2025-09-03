using exo_cinema;

List<Movie> frenchMovies = new List<Movie>() {
new Movie() { Title = "Le fabuleux destin d'Amélie Poulain", Genre = "Comédie", Rating = 8.3, Year = 2001, LanguageOptions = new string[] {"Français", "English"}, StreamingPlatforms = new string[] {"Netflix", "Hulu"} },
new Movie() { Title = "Intouchables", Genre = "Comédie", Rating = 8.5, Year = 2011, LanguageOptions = new string[] {"Français"}, StreamingPlatforms = new string[] {"Netflix", "Amazon"} },
new Movie() { Title = "The Matrix", Genre = "Science-Fiction", Rating = 8.7, Year = 1999, LanguageOptions = new string[] {"English", "Español"}, StreamingPlatforms = new string[] {"Hulu", "Amazon"} },
new Movie() { Title = "La Vie est belle", Genre = "Drame", Rating = 8.6, Year = 1946, LanguageOptions = new string[] {"Français", "Italiano"}, StreamingPlatforms = new string[] {"Netflix"} },
new Movie() { Title = "Gran Torino", Genre = "Drame", Rating = 8.2, Year = 2008, LanguageOptions = new string[] {"English"}, StreamingPlatforms = new string[] {"Hulu"} },
new Movie() { Title = "La Haine", Genre = "Drame", Rating = 8.1, Year = 1995, LanguageOptions = new string[] {"Français"}, StreamingPlatforms = new string[] {"Netflix"} },
new Movie() { Title = "Oldboy", Genre = "Thriller", Rating = 8.4, Year = 2003, LanguageOptions = new string[] {"Coréen", "English"}, StreamingPlatforms = new string[] {"Amazon"} }
};

// Ex1
List<Movie> MoviesFiltered1 = frenchMovies.Where(x => x.Genre != "Comédie" && x.Genre != "Drame").ToList();
Console.WriteLine("Ex 1 : ");
MoviesFiltered1.ForEach(i => Console.WriteLine($"{i.Title}"));


Console.WriteLine();
// Ex2 - CHANGEMENT (inférieur à 8.5 pour avoir des résultats)
List<Movie> MoviesFiltered2 = frenchMovies.Where(r => r.Rating < 8.5).ToList();
Console.WriteLine("Ex 2 : ");
MoviesFiltered2.ForEach(i => Console.WriteLine($"{i.Title} - rating : {i.Rating}"));


Console.WriteLine();
// Ex3
List<Movie> MoviesFiltered3 = frenchMovies.Where(annee => annee.Year < 2000).ToList();
Console.WriteLine("Ex 3 : ");
MoviesFiltered3.ForEach(i => Console.WriteLine($"{i.Title} - Year : {i.Year}"));


Console.WriteLine();
// Ex4
List<Movie> MoviesFiltered4 = frenchMovies.Where(d => !d.LanguageOptions.Contains("Français")).ToList();
Console.WriteLine("Ex 4 : ");
MoviesFiltered4.ForEach(i => Console.WriteLine($"{i.Title}"));


