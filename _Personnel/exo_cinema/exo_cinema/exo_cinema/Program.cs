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
// Ex2 - CHANGEMENT (inférieur à 8.8 pour avoir des résultats)
List<Movie> MoviesFiltered2 = frenchMovies.Where(r => r.Rating < 8.8).ToList();
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


Console.WriteLine();
// Ex5
List<Movie> MoviesFiltered5 = frenchMovies.Where(d => !d.StreamingPlatforms.Contains("Netflix")).ToList();
Console.WriteLine("Ex 5 : ");
MoviesFiltered5.ForEach(i => Console.WriteLine($"{i.Title}"));


Console.WriteLine();
// Version 2 : Cumul
List<Movie> MoviesFilteredCumul = frenchMovies.Where(d => !d.StreamingPlatforms.Contains("Netflix")).Where(d => !d.LanguageOptions.Contains("Français")).Where(annee => annee.Year < 2000).Where(r => r.Rating < 8.8).ToList();
Console.WriteLine("Version 2 (Cumul) : ");
MoviesFilteredCumul.ForEach(i => Console.WriteLine($"{i.Title}"));


Console.WriteLine();
// Version 3 : Dynamique

List<Movie> MoviesFilteredDyna = frenchMovies;

Console.Write("Activer Ex1 (exclure Comédie et Drame) ? (o/n) : ");
string rep1 = Console.ReadLine();
if (rep1 == "o")
{
    MoviesFilteredDyna = MoviesFilteredDyna.Where(x => x.Genre != "Comédie" && x.Genre != "Drame").ToList();
}

Console.Write("Activer Ex2 (note < 8.8) ? (o/n) : ");
string rep2 = Console.ReadLine();
if (rep2 == "o")
{
    MoviesFilteredDyna = MoviesFilteredDyna.Where(r => r.Rating < 8.8).ToList();
}

Console.Write("Activer Ex3 (année < 2000) ? (o/n) : ");
string rep3 = Console.ReadLine();
if (rep3 == "o")
{
    MoviesFilteredDyna = MoviesFilteredDyna.Where(a => a.Year < 2000).ToList();
}

Console.Write("Activer Ex4 (sans Français dans les langues) ? (o/n) : ");
string rep4 = Console.ReadLine();
if (rep4 == "o")
{
    MoviesFilteredDyna = MoviesFilteredDyna.Where(d => !d.LanguageOptions.Contains("Français")).ToList();
}

Console.Write("Activer Ex5 (sans Netflix) ? (o/n) : ");
string rep5 = Console.ReadLine();
if (rep5 == "o")
{
    MoviesFilteredDyna = MoviesFilteredDyna.Where(d => !d.StreamingPlatforms.Contains("Netflix")).ToList();
}

Console.WriteLine();
Console.WriteLine("Résultats de la Version 2 (dynamique) :");
if (MoviesFilteredDyna.Count == 0)
{
    Console.WriteLine("Aucun film correspond");
}
else
{
    foreach (var m in MoviesFilteredDyna)
    {
        Console.WriteLine(m.Title);
    }
}


