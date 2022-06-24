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
	.Where(x => x.Title.Contains("greatest hits"))
	.Take(5)