// See https://aka.ms/new-console-template for more information
using MusicStore;
using Microsoft.EntityFrameworkCore;

ShowSqlDemo();

void SelectNPlusOneDemo()
{
    using (var db = new MusicStoreDb())
    {
        foreach (var album in db.Albums.Where(a => a.Title.Contains("live")).Include(a => a.Artist))
        {
            Console.WriteLine($"FOUND ALBUM: {album.Title} by {album.Artist.Name}");
        }
        Console.ReadLine();
    }
}


void SelectNPlusOneDemoAnonymousObject()
{
    using (var db = new MusicStoreDb())
    {
        foreach (var album in db.Albums.Where(a => a.Title.Contains("live"))
            .Select(a => new { a.Title, ArtistName = a.Artist.Name}))
        {
            Console.WriteLine($"FOUND ALBUM: {album.Title} by {album.ArtistName}");
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
        //db.Database.Log = s => Console.WriteLine("DEBUG: " + s.TrimEnd());
        foreach (var album in albums)
        {
            Console.WriteLine($"Found Album: {album.Title}");
        }
        Console.ReadLine();
    }

}