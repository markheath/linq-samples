<Query Kind="Statements">
  <Connection>
    <ID>5eb5d186-a779-490b-bfd9-ba9e62eca475</ID>
    <Persist>true</Persist>
    <Server>(localdb)\v11.0</Server>
    <Database>SuaveMusicStore</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

foreach (var album in Albums.Where(a => a.Title.Contains("live")))
{
	Console.WriteLine($"{album.Title} by {album.Artist.Name}");
}


foreach (var album in Albums.Where(a => a.Title.Contains("live"))
		.Select(a => new { a.Title, ArtistName = a.Artist.Name}))
{
	Console.WriteLine($"{album.Title} by {album.ArtistName}");
}
// ENTITY FRAMEWORK
foreach (var album in Albums.Include("Artist").Where(a => a.Title.Contains("live")))
{
	Console.WriteLine($"{album.Title} by {album.Artist.Name}");
}

