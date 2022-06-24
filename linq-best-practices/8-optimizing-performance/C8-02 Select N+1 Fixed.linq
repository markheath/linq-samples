<Query Kind="Statements">
  <Connection>
    <ID>1c461ffe-6ea4-43d1-8abf-d82637493781</ID>
    <NamingServiceVersion>2</NamingServiceVersion>
    <Persist>true</Persist>
    <Driver Assembly="(internal)" PublicKeyToken="no-strong-name">LINQPad.Drivers.EFCore.DynamicDriver</Driver>
    <Server>(localdb)\MSSQLLocalDB</Server>
    <DisplayName>EF Core Music Store</DisplayName>
    <Database>MvcMusicStore</Database>
    <DriverData>
      <PreserveNumeric1>True</PreserveNumeric1>
      <EFProvider>Microsoft.EntityFrameworkCore.SqlServer</EFProvider>
    </DriverData>
  </Connection>
</Query>

foreach (var album in Albums.Where(a => a.Title.Contains("live"))
		.Select(a => new { a.Title, ArtistName = a.Artist.Name}))
{
	Console.WriteLine($"{album.Title} by {album.ArtistName}");
}
