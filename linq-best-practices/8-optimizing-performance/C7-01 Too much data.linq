<Query Kind="Expression">
  <Connection>
    <ID>de92fc78-e4be-4fe2-8a70-b3b16bd270ee</ID>
    <NamingServiceVersion>2</NamingServiceVersion>
    <Persist>true</Persist>
    <Server>(localdb)\MSSQLLocalDB</Server>
    <AllowDateOnlyTimeOnly>true</AllowDateOnlyTimeOnly>
    <Database>MvcMusicStore</Database>
  </Connection>
</Query>

Albums
	//.ToList()
	.Where(x => x.Title.Contains("greatest hits"))
	//.Where(x => x.Title.ToLower().Contains("greatest hits"))
	//.Where(x => x.Title.IndexOf("greatest hits", 
	//	StringComparison.CurrentCultureIgnoreCase) >= 0)
	.OrderBy(x => x.Artist.Name)
	.Take(5)