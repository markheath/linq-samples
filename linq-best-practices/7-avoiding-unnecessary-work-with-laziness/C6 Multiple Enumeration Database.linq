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

Albums.Where(a => a.Title.Contains("Greatest Hits")).Dump();
Albums.Where(a => a.Title.Contains("Live")).Dump();

var albumsInMemory = Albums.ToList();
albumsInMemory.Where(a => a.Title.Contains("Greatest Hits")).Dump();
albumsInMemory.Where(a => a.Title.Contains("Live")).Dump();