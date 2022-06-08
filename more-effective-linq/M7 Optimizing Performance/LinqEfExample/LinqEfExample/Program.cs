using System;
using System.Data.Entity;
using System.Linq;

namespace LinqEfExample
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new MusicStoreDb())
            {
                db.Database.Log = s => Console.WriteLine("DEBUG: " + s.TrimEnd());
                foreach (var album in db.Albums.Where(a => a.Title.Contains("live")).Include("Artist"))
                {
                    Console.WriteLine($"{album.Title} by {album.Artist.Name}");
                }
                Console.ReadLine();
            }

        }










        void ShowSqlDemo()
        {
            using (var db = new MusicStoreDb())
            {
                var albums = db.Albums
                    .Where(x => x.Title.Contains("greatest hits"))
                    .OrderBy(x => x.Artist.Name)
                    .Take(5);
                db.Database.Log = s => Console.WriteLine("DEBUG: " + s.TrimEnd());
                foreach (var album in albums)
                {
                    Console.WriteLine($"Found Album: {album.Title}");
                }
                Console.ReadLine();
            }

        }
    }
}
