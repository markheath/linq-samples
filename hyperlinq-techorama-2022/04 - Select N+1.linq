<Query Kind="Statements">
  <Connection>
    <ID>de92fc78-e4be-4fe2-8a70-b3b16bd270ee</ID>
    <NamingServiceVersion>2</NamingServiceVersion>
    <Persist>true</Persist>
    <Server>(localdb)\MSSQLLocalDB</Server>
    <AllowDateOnlyTimeOnly>true</AllowDateOnlyTimeOnly>
    <Database>MvcMusicStore</Database>
  </Connection>
</Query>

var greatestHits = Albums
	.Where(a => a.Title.Contains("greatest hits"));

foreach(var album in greatestHits)
{
	Console.WriteLine($"{album.Title} by {album.Artist.Name}");
}
	
