<Query Kind="Expression">
  <Connection>
    <ID>5eb5d186-a779-490b-bfd9-ba9e62eca475</ID>
    <Persist>true</Persist>
    <Server>(localdb)\v11.0</Server>
    <Database>SuaveMusicStore</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

Albums.Where(x => x.Title.Contains("greatest hits")).Take(5).Select(a => new { a.Title, a.Artist.Name})