<Query Kind="Expression">
  <Connection>
    <ID>014da8ef-d9ef-4e5b-ba7d-289dbadf324e</ID>
    <Persist>true</Persist>
    <Server>(localdb)\MSSQLLocalDB</Server>
    <Database>MvcMusicStore</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

// Good - one query with a join
Albums
	.Where(a => a.Artist.Name.StartsWith("A"))
	.OrderBy(a => a.Artist.Name)
	.Select(a => new { Artist = a.Artist.Name, Album = a.Title })
	.Take(5)


Albums
	//.AsEnumerable()// ToList()
	.Where(a => a.Artist.Name.Count(c => c == ' ') > 2)
    .OrderBy(a => a.Artist.Name)
   .Select(a => new { Artist = a.Artist.Name, Album = a.Title })
   .Take(5)


//	.ToList()
//	.Take(5)