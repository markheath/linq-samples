<Query Kind="Statements">
  <Connection>
    <ID>0b94e0e6-e5dc-4de8-ac44-6aaf67a6c1b8</ID>
    <Persist>true</Persist>
    <Server>(localdb)\v11.0</Server>
    <Database>MusicStore</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

Albums.Where(a => a.Title.Contains("Greatest Hits")).Dump();
Albums.Where(a => a.Title.Contains("Live")).Dump();

var albumsInMemory = Albums.ToList();
albumsInMemory.Where(a => a.Title.Contains("Greatest Hits")).Dump();
albumsInMemory.Where(a => a.Title.Contains("Live")).Dump();