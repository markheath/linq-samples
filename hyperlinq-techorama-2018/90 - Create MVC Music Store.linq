<Query Kind="SQL">
  <Connection>
    <ID>014da8ef-d9ef-4e5b-ba7d-289dbadf324e</ID>
    <Server>(localdb)\MSSQLLocalDB</Server>
    <Database>MvcMusicStore</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

CREATE DATABASE
            [MvcMusicStore]
        ON PRIMARY (
           NAME=MvcMusicStore_data,
           FILENAME = 'C:\Users\markh\code\db\MvcMusicStore.mdf'
        )
        LOG ON (
            NAME=MvcMusicStore_log,
            FILENAME = 'C:\Users\markh\code\db\MvcMusicStore_log.ldf'
        )
/* if mdf already exists, use this line */
FOR ATTACH;  