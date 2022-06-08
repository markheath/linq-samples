<Query Kind="Expression">
  <Connection>
    <ID>014da8ef-d9ef-4e5b-ba7d-289dbadf324e</ID>
    <Persist>true</Persist>
    <Server>(localdb)\MSSQLLocalDB</Server>
    <Database>MvcMusicStore</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

Albums.OrderByDescending(a => a.Price).First()