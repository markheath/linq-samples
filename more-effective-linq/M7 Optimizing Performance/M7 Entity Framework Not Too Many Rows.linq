<Query Kind="Expression">
  <Connection>
    <ID>0b94e0e6-e5dc-4de8-ac44-6aaf67a6c1b8</ID>
    <Persist>true</Persist>
    <Server>(localdb)\v11.0</Server>
    <Database>MusicStore</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

Albums
	//.ToList()
	//.Where(x => x.Title.Contains("greatest hits"))
	//.Where(x => x.Title.ToLower().Contains("greatest hits"))
	.Where(x => x.Title.IndexOf("greatest hits", 
		StringComparison.CurrentCultureIgnoreCase) >= 0)
	.OrderBy(x => x.Artist.Name)
	.Take(5)