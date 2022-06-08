<Query Kind="SQL">
  <Connection>
    <ID>014da8ef-d9ef-4e5b-ba7d-289dbadf324e</ID>
    <Persist>true</Persist>
    <Server>(localdb)\MSSQLLocalDB</Server>
    <Database>MvcMusicStore</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>



CREATE TABLE [dbo].[Order](
	[OrderId] [int] IDENTITY(1,1) NOT NULL,
	[OrderDate] [datetime] NOT NULL,
	[Username] [nvarchar](256) NULL,
	[FirstName] [nvarchar](160) NULL,
	[LastName] [nvarchar](160) NULL,
	[Address] [nvarchar](70) NULL,
	[City] [nvarchar](40) NULL,
	[State] [nvarchar](40) NULL,
	[PostalCode] [nvarchar](10) NULL,
	[Country] [nvarchar](40) NULL,
	[Phone] [nvarchar](24) NULL,
	[Email] [nvarchar](160) NULL,
	[Total] [numeric](10, 2) NOT NULL,
 CONSTRAINT [PK__Invoice__D796AAB51A14E395] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

CREATE NONCLUSTERED INDEX [IPK_Invoice] ON [dbo].[Order] 
(
	[OrderId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]

SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[Genre](
	[GenreId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](120) NULL,
	[Description] [nvarchar](4000) NULL,
PRIMARY KEY CLUSTERED 
(
	[GenreId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

CREATE NONCLUSTERED INDEX [IPK_Genre] ON [dbo].[Genre] 
(
	[GenreId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]

SET IDENTITY_INSERT [dbo].[Genre] ON
INSERT [dbo].[Genre] ([GenreId], [Name], [Description]) VALUES (1, N'Rock', N'Rock and Roll is a form of rock music developed in the 1950s and 1960s. Rock music combines many kinds of music from the United States, such as country music, folk music, church music, work songs, blues and jazz.')
INSERT [dbo].[Genre] ([GenreId], [Name], [Description]) VALUES (2, N'Jazz', N'Jazz is a type of music which was invented in the United States. Jazz music combines African-American music with European music. Some common jazz instruments include the saxophone, trumpet, piano, double bass, and drums.')
INSERT [dbo].[Genre] ([GenreId], [Name], [Description]) VALUES (3, N'Metal', N'Heavy Metal is a loud, aggressive style of Rock music. The bands who play heavy-metal music usually have one or two guitars, a bass guitar and drums. In some bands, electronic keyboards, organs, or other instruments are used. Heavy metal songs are loud and powerful-sounding, and have strong rhythms that are repeated. There are many different types of Heavy Metal, some of which are described below. Heavy metal bands sometimes dress in jeans, leather jackets, and leather boots, and have long hair. Heavy metal bands sometimes behave in a dramatic way when they play their instruments or sing. However, many heavy metal bands do not like to do this.')
INSERT [dbo].[Genre] ([GenreId], [Name], [Description]) VALUES (4, N'Alternative', N'Alternative rock is a type of rock music that became popular in the 1980s and became widely popular in the 1990s. Alternative rock is made up of various subgenres that have come out of the indie music scene since the 1980s, such as grunge, indie rock, Britpop, thic rock, and indie pop. These genres are sorted by their collective types of punk, which laid the groundwork for alternative music in the 1970s.')
INSERT [dbo].[Genre] ([GenreId], [Name], [Description]) VALUES (5, N'Disco', N'Disco is a style of pop music that was popular in the mid-1970s. Disco music has a strong beat that people can dance to. People usually dance to disco music at bars called disco clubs. The word "disco" is also used to refer to the style of dancing that people do to disco music, or to the style of clothes that people wear to  disco dancing. Disco was at its most popular in the United States and Europe in the 1970s and early 1980s. Disco was brought into the mainstream by the hit movie Saturday Night Fever, which was released in 1977. This movie, which starred John Travolta, showed people doing disco dancing. Many radio stations played disco in the late 1970s.')
INSERT [dbo].[Genre] ([GenreId], [Name], [Description]) VALUES (6, N'Blues', N'The blues is a form of music that started in the United States during the start of the 20th century. It was started by former African slaves from spirituals, praise songs, and chants. The first blues songs were called Delta blues. These songs came from the area near the mouth of the Mississippi River.')
INSERT [dbo].[Genre] ([GenreId], [Name], [Description]) VALUES (7, N'Latin', N'Latin American music is the music of all countries in Latin America (and the Caribbean) and comes in many varieties. Latin America is home to musical styles such as the simple, rural conjunto music of northern Mexico, the sophisticated habanera of Cuba, the rhythmic sounds of the Puerto Rican plena, the symphonies of Heitor Villa-Lobos, and the simple and moving Andean flute. Music has played an important part recently in Latin America''s politics, the nueva canción movement being a prime example. Latin music is very diverse, with the only truly unifying thread being the use of Latin-derived languages, predominantly the Spanish language, the Portuguese language in Brazil, and to a lesser extent, Latin-derived creole languages, such as those found in Haiti.')
INSERT [dbo].[Genre] ([GenreId], [Name], [Description]) VALUES (8, N'Reggae', N'Reggae is a music genre first developed in Jamaica in the late 1960s. While sometimes used in a broader sense to refer to most types of Jamaican music, the term reggae more properly denotes a particular music style that originated following on the development of ska and rocksteady.')
INSERT [dbo].[Genre] ([GenreId], [Name], [Description]) VALUES (9, N'Pop', N'Pop music is a music genre that developed from the mid-1950s as a softer alternative to rock ''n'' roll and later to rock music. It has a focus on commercial recording, often oriented towards a youth market, usually through the medium of relatively short and simple love songs. While these basic elements of the genre have remained fairly constant, pop music has absorbed influences from most other forms of popular music, particularly borrowing from the development of rock music, and utilizing key technological innovations to produce new variations on existing themes.')
INSERT [dbo].[Genre] ([GenreId], [Name], [Description]) VALUES (10, N'Classical', N'Classical music is a very general term which normally refers to the standard music of countries in the Western world. It is music that has been composed by musicians who are trained in the art of writing music (composing) and written down in music notation so that other musicians can play it. Classical music can also be described as "art music" because great art (skill) is needed to compose it and to perform it well. Classical music differs from pop music because it is not made just in order to be popular for a short time or just to be a commercial success.')
SET IDENTITY_INSERT [dbo].[Genre] OFF
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[Artist](
	[ArtistId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](120) NULL,
PRIMARY KEY CLUSTERED 
(
	[ArtistId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

CREATE NONCLUSTERED INDEX [IPK_Artist] ON [dbo].[Artist] 
(
	[ArtistId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]

SET IDENTITY_INSERT [dbo].[Artist] ON
INSERT [dbo].[Artist] ([ArtistId], [Name]) VALUES (1, N'AC/DC')
INSERT [dbo].[Artist] ([ArtistId], [Name]) VALUES (2, N'Accept')
INSERT [dbo].[Artist] ([ArtistId], [Name]) VALUES (3, N'Aerosmith')
INSERT [dbo].[Artist] ([ArtistId], [Name]) VALUES (4, N'Alanis Morissette')
INSERT [dbo].[Artist] ([ArtistId], [Name]) VALUES (5, N'Alice In Chains')
INSERT [dbo].[Artist] ([ArtistId], [Name]) VALUES (6, N'Antônio Carlos Jobim')
INSERT [dbo].[Artist] ([ArtistId], [Name]) VALUES (7, N'Apocalyptica')
INSERT [dbo].[Artist] ([ArtistId], [Name]) VALUES (8, N'Audioslave')
INSERT [dbo].[Artist] ([ArtistId], [Name]) VALUES (10, N'Billy Cobham')
INSERT [dbo].[Artist] ([ArtistId], [Name]) VALUES (11, N'Black Label Society')
INSERT [dbo].[Artist] ([ArtistId], [Name]) VALUES (12, N'Black Sabbath')
INSERT [dbo].[Artist] ([ArtistId], [Name]) VALUES (14, N'Bruce Dickinson')
INSERT [dbo].[Artist] ([ArtistId], [Name]) VALUES (15, N'Buddy Guy')
INSERT [dbo].[Artist] ([ArtistId], [Name]) VALUES (16, N'Caetano Veloso')
INSERT [dbo].[Artist] ([ArtistId], [Name]) VALUES (17, N'Chico Buarque')
INSERT [dbo].[Artist] ([ArtistId], [Name]) VALUES (18, N'Chico Science & Nação Zumbi')
INSERT [dbo].[Artist] ([ArtistId], [Name]) VALUES (19, N'Cidade Negra')
INSERT [dbo].[Artist] ([ArtistId], [Name]) VALUES (20, N'Cláudio Zoli')
INSERT [dbo].[Artist] ([ArtistId], [Name]) VALUES (21, N'Various Artists')
INSERT [dbo].[Artist] ([ArtistId], [Name]) VALUES (22, N'Led Zeppelin')
INSERT [dbo].[Artist] ([ArtistId], [Name]) VALUES (23, N'Frank Zappa & Captain Beefheart')
INSERT [dbo].[Artist] ([ArtistId], [Name]) VALUES (24, N'Marcos Valle')
INSERT [dbo].[Artist] ([ArtistId], [Name]) VALUES (27, N'Gilberto Gil')
INSERT [dbo].[Artist] ([ArtistId], [Name]) VALUES (37, N'Ed Motta')
INSERT [dbo].[Artist] ([ArtistId], [Name]) VALUES (41, N'Elis Regina')
INSERT [dbo].[Artist] ([ArtistId], [Name]) VALUES (42, N'Milton Nascimento')
INSERT [dbo].[Artist] ([ArtistId], [Name]) VALUES (46, N'Jorge Ben')
INSERT [dbo].[Artist] ([ArtistId], [Name]) VALUES (50, N'Metallica')
INSERT [dbo].[Artist] ([ArtistId], [Name]) VALUES (51, N'Queen')
INSERT [dbo].[Artist] ([ArtistId], [Name]) VALUES (52, N'Kiss')
INSERT [dbo].[Artist] ([ArtistId], [Name]) VALUES (53, N'Spyro Gyra')
INSERT [dbo].[Artist] ([ArtistId], [Name]) VALUES (55, N'David Coverdale')
INSERT [dbo].[Artist] ([ArtistId], [Name]) VALUES (56, N'nzaguinha')
INSERT [dbo].[Artist] ([ArtistId], [Name]) VALUES (58, N'Deep Purple')
INSERT [dbo].[Artist] ([ArtistId], [Name]) VALUES (59, N'Santana')
INSERT [dbo].[Artist] ([ArtistId], [Name]) VALUES (68, N'Miles Davis')
INSERT [dbo].[Artist] ([ArtistId], [Name]) VALUES (72, N'Vinícius De Moraes')
INSERT [dbo].[Artist] ([ArtistId], [Name]) VALUES (76, N'Creedence Clearwater Revival')
INSERT [dbo].[Artist] ([ArtistId], [Name]) VALUES (77, N'Cássia Eller')
INSERT [dbo].[Artist] ([ArtistId], [Name]) VALUES (79, N'Dennis Chambers')
INSERT [dbo].[Artist] ([ArtistId], [Name]) VALUES (80, N'Djavan')
INSERT [dbo].[Artist] ([ArtistId], [Name]) VALUES (81, N'Eric Clapton')
INSERT [dbo].[Artist] ([ArtistId], [Name]) VALUES (82, N'Faith No More')
INSERT [dbo].[Artist] ([ArtistId], [Name]) VALUES (83, N'Falamansa')
INSERT [dbo].[Artist] ([ArtistId], [Name]) VALUES (84, N'Foo Fighters')
INSERT [dbo].[Artist] ([ArtistId], [Name]) VALUES (86, N'Funk Como Le Gusta')
INSERT [dbo].[Artist] ([ArtistId], [Name]) VALUES (87, N'dsmack')
INSERT [dbo].[Artist] ([ArtistId], [Name]) VALUES (88, N'Guns N'' Roses')
INSERT [dbo].[Artist] ([ArtistId], [Name]) VALUES (89, N'Incognito')
INSERT [dbo].[Artist] ([ArtistId], [Name]) VALUES (90, N'Iron Maiden')
INSERT [dbo].[Artist] ([ArtistId], [Name]) VALUES (92, N'Jamiroquai')
INSERT [dbo].[Artist] ([ArtistId], [Name]) VALUES (94, N'Jimi Hendrix')
INSERT [dbo].[Artist] ([ArtistId], [Name]) VALUES (95, N'Joe Satriani')
INSERT [dbo].[Artist] ([ArtistId], [Name]) VALUES (96, N'Jota Quest')
INSERT [dbo].[Artist] ([ArtistId], [Name]) VALUES (98, N'Judas Priest')
INSERT [dbo].[Artist] ([ArtistId], [Name]) VALUES (99, N'Legião Urbana')
INSERT [dbo].[Artist] ([ArtistId], [Name]) VALUES (100, N'Lenny Kravitz')
INSERT [dbo].[Artist] ([ArtistId], [Name]) VALUES (101, N'Lulu Santos')
INSERT [dbo].[Artist] ([ArtistId], [Name]) VALUES (102, N'Marillion')
INSERT [dbo].[Artist] ([ArtistId], [Name]) VALUES (103, N'Marisa Monte')
INSERT [dbo].[Artist] ([ArtistId], [Name]) VALUES (105, N'Men At Work')
INSERT [dbo].[Artist] ([ArtistId], [Name]) VALUES (106, N'Motörhead')
INSERT [dbo].[Artist] ([ArtistId], [Name]) VALUES (109, N'Mötley Crüe')
INSERT [dbo].[Artist] ([ArtistId], [Name]) VALUES (110, N'Nirvana')
INSERT [dbo].[Artist] ([ArtistId], [Name]) VALUES (111, N'O Terço')
INSERT [dbo].[Artist] ([ArtistId], [Name]) VALUES (112, N'Olodum')
INSERT [dbo].[Artist] ([ArtistId], [Name]) VALUES (113, N'Os Paralamas Do Sucesso')
INSERT [dbo].[Artist] ([ArtistId], [Name]) VALUES (114, N'Ozzy Osbourne')
INSERT [dbo].[Artist] ([ArtistId], [Name]) VALUES (115, N'Page & Plant')
INSERT [dbo].[Artist] ([ArtistId], [Name]) VALUES (117, N'Paul D''Ianno')
INSERT [dbo].[Artist] ([ArtistId], [Name]) VALUES (118, N'Pearl Jam')
INSERT [dbo].[Artist] ([ArtistId], [Name]) VALUES (120, N'Pink Floyd')
INSERT [dbo].[Artist] ([ArtistId], [Name]) VALUES (124, N'R.E.M.')
INSERT [dbo].[Artist] ([ArtistId], [Name]) VALUES (126, N'Raul Seixas')
INSERT [dbo].[Artist] ([ArtistId], [Name]) VALUES (127, N'Red Hot Chili Peppers')
INSERT [dbo].[Artist] ([ArtistId], [Name]) VALUES (128, N'Rush')
INSERT [dbo].[Artist] ([ArtistId], [Name]) VALUES (130, N'Skank')
INSERT [dbo].[Artist] ([ArtistId], [Name]) VALUES (132, N'Soundgarden')
INSERT [dbo].[Artist] ([ArtistId], [Name]) VALUES (133, N'Stevie Ray Vaughan & Double Trouble')
INSERT [dbo].[Artist] ([ArtistId], [Name]) VALUES (134, N'Stone Temple Pilots')
INSERT [dbo].[Artist] ([ArtistId], [Name]) VALUES (135, N'System Of A Down')
INSERT [dbo].[Artist] ([ArtistId], [Name]) VALUES (136, N'Terry Bozzio, Tony Levin & Steve Stevens')
INSERT [dbo].[Artist] ([ArtistId], [Name]) VALUES (137, N'The Black Crowes')
INSERT [dbo].[Artist] ([ArtistId], [Name]) VALUES (139, N'The Cult')
INSERT [dbo].[Artist] ([ArtistId], [Name]) VALUES (140, N'The Doors')
INSERT [dbo].[Artist] ([ArtistId], [Name]) VALUES (141, N'The Police')
INSERT [dbo].[Artist] ([ArtistId], [Name]) VALUES (142, N'The Rolling Stones')
INSERT [dbo].[Artist] ([ArtistId], [Name]) VALUES (144, N'The Who')
INSERT [dbo].[Artist] ([ArtistId], [Name]) VALUES (145, N'Tim Maia')
INSERT [dbo].[Artist] ([ArtistId], [Name]) VALUES (150, N'U2')
INSERT [dbo].[Artist] ([ArtistId], [Name]) VALUES (151, N'UB40')
INSERT [dbo].[Artist] ([ArtistId], [Name]) VALUES (152, N'Van Halen')
INSERT [dbo].[Artist] ([ArtistId], [Name]) VALUES (153, N'Velvet Revolver')
INSERT [dbo].[Artist] ([ArtistId], [Name]) VALUES (155, N'Zeca Padinho')
INSERT [dbo].[Artist] ([ArtistId], [Name]) VALUES (157, N'Dread Zeppelin')
INSERT [dbo].[Artist] ([ArtistId], [Name]) VALUES (179, N'Scorpions')
INSERT [dbo].[Artist] ([ArtistId], [Name]) VALUES (196, N'Cake')
INSERT [dbo].[Artist] ([ArtistId], [Name]) VALUES (197, N'Aisha Duo')
INSERT [dbo].[Artist] ([ArtistId], [Name]) VALUES (200, N'The Posies')
INSERT [dbo].[Artist] ([ArtistId], [Name]) VALUES (201, N'Luciana Souza/Romero Lubambo')

print 'Processed 100 total records'
INSERT [dbo].[Artist] ([ArtistId], [Name]) VALUES (202, N'Aaron ldberg')
INSERT [dbo].[Artist] ([ArtistId], [Name]) VALUES (203, N'Nicolaus Esterhazy Sinfonia')
INSERT [dbo].[Artist] ([ArtistId], [Name]) VALUES (204, N'Temple of the Dog')
INSERT [dbo].[Artist] ([ArtistId], [Name]) VALUES (205, N'Chris Cornell')
INSERT [dbo].[Artist] ([ArtistId], [Name]) VALUES (206, N'Alberto Turco & Nova Schola Greriana')
INSERT [dbo].[Artist] ([ArtistId], [Name]) VALUES (208, N'English Concert & Trevor Pinnock')
INSERT [dbo].[Artist] ([ArtistId], [Name]) VALUES (211, N'Wilhelm Kempff')
INSERT [dbo].[Artist] ([ArtistId], [Name]) VALUES (212, N'Yo-Yo Ma')
INSERT [dbo].[Artist] ([ArtistId], [Name]) VALUES (213, N'Scholars Baroque Ensemble')
INSERT [dbo].[Artist] ([ArtistId], [Name]) VALUES (217, N'Royal Philharmonic Orchestra & Sir Thomas Beecham')
INSERT [dbo].[Artist] ([ArtistId], [Name]) VALUES (219, N'Britten Sinfonia, Ivor Bolton & Lesley Garrett')
INSERT [dbo].[Artist] ([ArtistId], [Name]) VALUES (221, N'Sir Georg Solti & Wiener Philharmoniker')
INSERT [dbo].[Artist] ([ArtistId], [Name]) VALUES (223, N'London Symphony Orchestra & Sir Charles Mackerras')
INSERT [dbo].[Artist] ([ArtistId], [Name]) VALUES (224, N'Barry Wordsworth & BBC Concert Orchestra')
INSERT [dbo].[Artist] ([ArtistId], [Name]) VALUES (226, N'Eugene Ormandy')
INSERT [dbo].[Artist] ([ArtistId], [Name]) VALUES (229, N'Boston Symphony Orchestra & Seiji Ozawa')
INSERT [dbo].[Artist] ([ArtistId], [Name]) VALUES (230, N'Aaron Copland & London Symphony Orchestra')
INSERT [dbo].[Artist] ([ArtistId], [Name]) VALUES (231, N'Ton Koopman')
INSERT [dbo].[Artist] ([ArtistId], [Name]) VALUES (232, N'Sergei Prokofiev & Yuri Temirkanov')
INSERT [dbo].[Artist] ([ArtistId], [Name]) VALUES (233, N'Chica Symphony Orchestra & Fritz Reiner')
INSERT [dbo].[Artist] ([ArtistId], [Name]) VALUES (234, N'Orchestra of The Age of Enlightenment')
INSERT [dbo].[Artist] ([ArtistId], [Name]) VALUES (236, N'James Levine')
INSERT [dbo].[Artist] ([ArtistId], [Name]) VALUES (237, N'Berliner Philharmoniker & Hans Rosbaud')
INSERT [dbo].[Artist] ([ArtistId], [Name]) VALUES (238, N'Maurizio Pollini')
INSERT [dbo].[Artist] ([ArtistId], [Name]) VALUES (240, N'Gustav Mahler')
INSERT [dbo].[Artist] ([ArtistId], [Name]) VALUES (242, N'Edo de Waart & San Francisco Symphony')
INSERT [dbo].[Artist] ([ArtistId], [Name]) VALUES (244, N'Choir Of Westminster Abbey & Simon Preston')
INSERT [dbo].[Artist] ([ArtistId], [Name]) VALUES (245, N'Michael Tilson Thomas & San Francisco Symphony')
INSERT [dbo].[Artist] ([ArtistId], [Name]) VALUES (247, N'The King''s Singers')
INSERT [dbo].[Artist] ([ArtistId], [Name]) VALUES (248, N'Berliner Philharmoniker & Herbert Von Karajan')
INSERT [dbo].[Artist] ([ArtistId], [Name]) VALUES (250, N'Christopher O''Riley')
INSERT [dbo].[Artist] ([ArtistId], [Name]) VALUES (251, N'Fretwork')
INSERT [dbo].[Artist] ([ArtistId], [Name]) VALUES (252, N'Amy Winehouse')
INSERT [dbo].[Artist] ([ArtistId], [Name]) VALUES (253, N'Calexico')
INSERT [dbo].[Artist] ([ArtistId], [Name]) VALUES (255, N'Yehudi Menuhin')
INSERT [dbo].[Artist] ([ArtistId], [Name]) VALUES (258, N'Les Arts Florissants & William Christie')
INSERT [dbo].[Artist] ([ArtistId], [Name]) VALUES (259, N'The 12 Cellists of The Berlin Philharmonic')
INSERT [dbo].[Artist] ([ArtistId], [Name]) VALUES (260, N'Adrian Leaper & Doreen de Feis')
INSERT [dbo].[Artist] ([ArtistId], [Name]) VALUES (261, N'Roger Norrington, London Classical Players')
INSERT [dbo].[Artist] ([ArtistId], [Name]) VALUES (264, N'Kent Nagano and Orchestre de l''Opéra de Lyon')
INSERT [dbo].[Artist] ([ArtistId], [Name]) VALUES (265, N'Julian Bream')
INSERT [dbo].[Artist] ([ArtistId], [Name]) VALUES (266, N'Martin Roscoe')
INSERT [dbo].[Artist] ([ArtistId], [Name]) VALUES (267, N'Göteborgs Symfoniker & Neeme Järvi')
INSERT [dbo].[Artist] ([ArtistId], [Name]) VALUES (270, N'Gerald Moore')
INSERT [dbo].[Artist] ([ArtistId], [Name]) VALUES (271, N'Mela Tenenbaum, Pro Musica Prague & Richard Kapp')
INSERT [dbo].[Artist] ([ArtistId], [Name]) VALUES (274, N'Nash Ensemble')
INSERT [dbo].[Artist] ([ArtistId], [Name]) VALUES (276, N'Chic')
INSERT [dbo].[Artist] ([ArtistId], [Name]) VALUES (277, N'Anita Ward')
INSERT [dbo].[Artist] ([ArtistId], [Name]) VALUES (278, N'Donna Summer')
SET IDENTITY_INSERT [dbo].[Artist] OFF
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[Album](
	[AlbumId] [int] IDENTITY(1,1) NOT NULL,
	[GenreId] [int] NOT NULL,
	[ArtistId] [int] NOT NULL,
	[Title] [nvarchar](160) NOT NULL,
	[Price] [numeric](10, 2) NOT NULL,
	[AlbumArtUrl] [nvarchar](1024) NULL CONSTRAINT [DF_Album_AlbumArtUrl]  DEFAULT (N'/Content/Images/placeholder.gif'),
 CONSTRAINT [PK__Album__97B4BE370AD2A005] PRIMARY KEY CLUSTERED 
(
	[AlbumId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

CREATE NONCLUSTERED INDEX [IFK_Artist_Album] ON [dbo].[Album] 
(
	[ArtistId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]

CREATE NONCLUSTERED INDEX [IPK_ProductItem] ON [dbo].[Album] 
(
	[AlbumId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]

SET IDENTITY_INSERT [dbo].[Album] ON
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (386, 1, 1, N'For Those About To Rock We Salute You', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (387, 1, 1, N'Let There Be Rock', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (388, 1, 100, N'Greatest Hits', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (389, 1, 102, N'Misplaced Childhood', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (390, 1, 105, N'The Best Of Men At Work', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (392, 1, 110, N'Nevermind', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (393, 1, 111, N'Compositores', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (394, 1, 114, N'Bark at the Moon (Remastered)', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (395, 1, 114, N'Blizzard of Ozz', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (396, 1, 114, N'Diary of a Madman (Remastered)', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (397, 1, 114, N'No More Tears (Remastered)', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (398, 1, 114, N'Speak of the Devil', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (399, 1, 115, N'Walking Into Clarksdale', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (400, 1, 117, N'The Beast Live', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (401, 1, 118, N'Live On Two Legs [Live]', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (402, 1, 118, N'Riot Act', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (403, 1, 118, N'Ten', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (404, 1, 118, N'Vs.', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (405, 1, 120, N'Dark Side Of The Moon', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (406, 1, 124, N'New Adventures In Hi-Fi', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (407, 1, 126, N'Raul Seixas', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (408, 1, 127, N'By The Way', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (409, 1, 127, N'Californication', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (410, 1, 128, N'Retrospective I (1974-1980)', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (411, 1, 130, N'Maquinarama', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (412, 1, 130, N'O Samba Poconé', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (413, 1, 132, N'A-Sides', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (414, 1, 134, N'Core', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (415, 1, 136, N'[1997] Black Light Syndrome', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (416, 1, 139, N'Beyond od And Evil', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (418, 1, 140, N'The Doors', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (419, 1, 141, N'The Police Greatest Hits', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (420, 1, 142, N'Hot Rocks, 1964-1971 (Disc 1)', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (421, 1, 142, N'No Security', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (422, 1, 142, N'Voodoo Lounge', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (423, 1, 144, N'My Generation - The Very Best Of The Who', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (424, 1, 150, N'Achtung Baby', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (425, 1, 150, N'B-Sides 1980-1990', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (426, 1, 150, N'How To Dismantle An Atomic Bomb', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (427, 1, 150, N'Pop', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (428, 1, 150, N'Rattle And Hum', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (429, 1, 150, N'The Best Of 1980-1990', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (430, 1, 150, N'War', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (431, 1, 150, N'Zooropa', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (432, 1, 152, N'Diver Down', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (433, 1, 152, N'The Best Of Van Halen, Vol. I', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (434, 1, 152, N'Van Halen III', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (435, 1, 152, N'Van Halen', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (436, 1, 153, N'Contraband', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (437, 1, 157, N'Un-Led-Ed', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (439, 1, 2, N'Balls to the Wall', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (440, 1, 2, N'Restless and Wild', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (441, 1, 200, N'Every Kind of Light', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (442, 1, 22, N'BBC Sessions [Disc 1] [Live]', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (443, 1, 22, N'BBC Sessions [Disc 2] [Live]', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (444, 1, 22, N'Coda', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (445, 1, 22, N'Houses Of The Holy', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (446, 1, 22, N'In Through The Out Door', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (447, 1, 22, N'IV', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (448, 1, 22, N'Led Zeppelin I', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (449, 1, 22, N'Led Zeppelin II', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (450, 1, 22, N'Led Zeppelin III', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (451, 1, 22, N'Physical Graffiti [Disc 1]', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (452, 1, 22, N'Physical Graffiti [Disc 2]', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (453, 1, 22, N'Presence', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (454, 1, 22, N'The Song Remains The Same (Disc 1)', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (455, 1, 22, N'The Song Remains The Same (Disc 2)', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (456, 1, 23, N'Bon Fury', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (457, 1, 3, N'Big Ones', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (458, 1, 4, N'Jagged Little Pill', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (459, 1, 5, N'Facelift', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (460, 1, 51, N'Greatest Hits I', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (461, 1, 51, N'Greatest Hits II', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (462, 1, 51, N'News Of The World', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (463, 1, 52, N'Greatest Kiss', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (464, 1, 52, N'Unplugged [Live]', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (465, 1, 55, N'Into The Light', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (466, 1, 58, N'Come Taste The Band', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (467, 1, 58, N'Deep Purple In Rock', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (468, 1, 58, N'Fireball', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (469, 1, 58, N'Machine Head', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (470, 1, 58, N'MK III The Final Concerts [Disc 1]', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (471, 1, 58, N'Purpendicular', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (472, 1, 58, N'Slaves And Masters', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (473, 1, 58, N'Stormbringer', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (474, 1, 58, N'The Battle Rages On', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (475, 1, 58, N'The Final Concerts (Disc 2)', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (476, 1, 59, N'Santana - As Years  By', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (477, 1, 59, N'Santana Live', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (478, 1, 59, N'Supernatural', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (479, 1, 76, N'Chronicle, Vol. 1', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (480, 1, 76, N'Chronicle, Vol. 2', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (481, 1, 8, N'Audioslave', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (482, 1, 82, N'King For A Day Fool For A Lifetime', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (483, 1, 84, N'In Your Honor [Disc 1]', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (484, 1, 84, N'In Your Honor [Disc 2]', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (485, 1, 84, N'The Colour And The Shape', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (486, 1, 88, N'Appetite for Destruction', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (487, 1, 88, N'Use Your Illusion I', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (488, 1, 90, N'A Matter of Life and Death', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')

print 'Processed 100 total records'
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (489, 1, 90, N'Brave New World', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (490, 1, 90, N'Fear Of The Dark', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (491, 1, 90, N'Live At Donington 1992 (Disc 1)', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (492, 1, 90, N'Live At Donington 1992 (Disc 2)', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (493, 1, 90, N'Rock In Rio [CD2]', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (494, 1, 90, N'The Number of The Beast', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (495, 1, 90, N'The X Factor', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (496, 1, 90, N'Virtual XI', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (497, 1, 92, N'Emergency On Planet Earth', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (498, 1, 94, N'Are You Experienced?', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (499, 1, 95, N'Surfing with the Alien (Remastered)', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (500, 10, 203, N'The Best of Beethoven', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (504, 10, 208, N'Pachelbel: Canon & Gigue', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (507, 10, 211, N'Bach: ldberg Variations', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (508, 10, 212, N'Bach: The Cello Suites', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (509, 10, 213, N'Handel: The Messiah (Highlights)', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (513, 10, 217, N'Haydn: Symphonies 99 - 104', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (515, 10, 219, N'A Soprano Inspired', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (517, 10, 221, N'Wagner: Favourite Overtures', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (519, 10, 223, N'Tchaikovsky: The Nutcracker', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (520, 10, 224, N'The Last Night of the Proms', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (523, 10, 226, N'Respighi:Pines of Rome', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (524, 10, 226, N'Strauss: Waltzes', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (525, 10, 229, N'Carmina Burana', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (526, 10, 230, N'A Copland Celebration, Vol. I', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (527, 10, 231, N'Bach: Toccata & Fugue in D Minor', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (528, 10, 232, N'Prokofiev: Symphony No.1', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (529, 10, 233, N'Scheherazade', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (530, 10, 234, N'Bach: The Brandenburg Concertos', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (532, 10, 236, N'Mascagni: Cavalleria Rusticana', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (533, 10, 237, N'Sibelius: Finlandia', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (537, 10, 242, N'Adams, John: The Chairman Dances', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (539, 10, 245, N'Berlioz: Symphonie Fantastique', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (540, 10, 245, N'Prokofiev: Romeo & Juliet', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (542, 10, 247, N'English Renaissance', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (544, 10, 248, N'Mozart: Symphonies Nos. 40 & 41', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (546, 10, 250, N'SCRIABIN: Vers la flamme', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (548, 10, 255, N'Bartok: Violin & Viola Concertos', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (551, 10, 259, N'South American Getaway', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (552, 10, 260, N'Górecki: Symphony No. 3', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (553, 10, 261, N'Purcell: The Fairy Queen', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (556, 10, 264, N'Weill: The Seven Deadly Sins', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (558, 10, 266, N'Szymanowski: Piano Works, Vol. 1', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (559, 10, 267, N'Nielsen: The Six Symphonies', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (562, 10, 274, N'Mozart: Chamber Music', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (563, 2, 10, N'The Best Of Billy Cobham', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (564, 2, 197, N'Quiet Songs', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (565, 2, 202, N'Worlds', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (566, 2, 27, N'Quanta Gente Veio ver--Bônus De Carnaval', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (567, 2, 53, N'Heart of the Night', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (568, 2, 53, N'Morning Dance', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (569, 2, 6, N'Warner 25 Anos', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (570, 2, 68, N'Miles Ahead', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (571, 2, 68, N'The Essential Miles Davis [Disc 1]', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (572, 2, 68, N'The Essential Miles Davis [Disc 2]', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (573, 2, 79, N'Outbreak', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (574, 2, 89, N'Blue Moods', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (575, 3, 100, N'Greatest Hits', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (576, 3, 106, N'Ace Of Spades', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (577, 3, 109, N'Motley Crue Greatest Hits', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (578, 3, 11, N'Alcohol Fueled Brewtality Live! [Disc 1]', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (579, 3, 11, N'Alcohol Fueled Brewtality Live! [Disc 2]', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (580, 3, 114, N'Tribute', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (581, 3, 12, N'Black Sabbath Vol. 4 (Remaster)', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (582, 3, 12, N'Black Sabbath', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (583, 3, 135, N'Mezmerize', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (584, 3, 14, N'Chemical Wedding', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (585, 3, 50, N'...And Justice For All', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (586, 3, 50, N'Black Album', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (587, 3, 50, N'Garage Inc. (Disc 1)', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (588, 3, 50, N'Garage Inc. (Disc 2)', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (589, 3, 50, N'Load', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (590, 3, 50, N'Master Of Puppets', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (591, 3, 50, N'ReLoad', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (592, 3, 50, N'Ride The Lightning', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (593, 3, 50, N'St. Anger', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (594, 3, 7, N'Plays Metallica By Four Cellos', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (595, 3, 87, N'Faceless', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (596, 3, 88, N'Use Your Illusion II', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (597, 3, 90, N'A Real Dead One', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (598, 3, 90, N'A Real Live One', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (599, 3, 90, N'Live After Death', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (600, 3, 90, N'No Prayer For The Dying', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (601, 3, 90, N'Piece Of Mind', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (602, 3, 90, N'Powerslave', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (603, 3, 90, N'Rock In Rio [CD1]', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (604, 3, 90, N'Rock In Rio [CD2]', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (605, 3, 90, N'Seventh Son of a Seventh Son', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (606, 3, 90, N'Somewhere in Time', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (607, 3, 90, N'The Number of The Beast', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (608, 3, 98, N'Living After Midnight', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (609, 4, 196, N'Cake: B-Sides and Rarities', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (610, 4, 204, N'Temple of the Dog', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (611, 4, 205, N'Carry On', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (612, 4, 253, N'Carried to Dust (Bonus Track Version)', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (613, 4, 8, N'Revelations', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (614, 6, 133, N'In Step', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (615, 6, 137, N'Live [Disc 1]', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (616, 6, 137, N'Live [Disc 2]', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (618, 6, 81, N'The Cream Of Clapton', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (619, 6, 81, N'Unplugged', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')

print 'Processed 200 total records'
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (620, 6, 90, N'Iron Maiden', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (623, 7, 103, N'Barulhinho Bom', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (624, 7, 112, N'Olodum', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (625, 7, 113, N'Acústico MTV', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (626, 7, 113, N'Arquivo II', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (627, 7, 113, N'Arquivo Os Paralamas Do Sucesso', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (628, 7, 145, N'Serie Sem Limite (Disc 1)', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (629, 7, 145, N'Serie Sem Limite (Disc 2)', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (630, 7, 155, N'Ao Vivo [IMPORT]', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (631, 7, 16, N'Prenda Minha', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (632, 7, 16, N'Sozinho Remix Ao Vivo', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (633, 7, 17, N'Minha Historia', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (634, 7, 18, N'Afrociberdelia', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (635, 7, 18, N'Da Lama Ao Caos', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (636, 7, 20, N'Na Pista', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (637, 7, 201, N'Duos II', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (638, 7, 21, N'Sambas De Enredo 2001', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (639, 7, 21, N'Vozes do MPB', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (640, 7, 24, N'Chill: Brazil (Disc 1)', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (641, 7, 27, N'Quanta Gente Veio Ver (Live)', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (642, 7, 37, N'The Best of Ed Motta', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (643, 7, 41, N'Elis Regina-Minha História', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (644, 7, 42, N'Milton Nascimento Ao Vivo', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (645, 7, 42, N'Minas', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (646, 7, 46, N'Jorge Ben Jor 25 Anos', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (647, 7, 56, N'Meus Momentos', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (648, 7, 6, N'Chill: Brazil (Disc 2)', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (649, 7, 72, N'Vinicius De Moraes', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (651, 7, 77, N'Cássia Eller - Sem Limite [Disc 1]', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (652, 7, 80, N'Djavan Ao Vivo - Vol. 02', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (653, 7, 80, N'Djavan Ao Vivo - Vol. 1', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (654, 7, 81, N'Unplugged', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (655, 7, 83, N'Deixa Entrar', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (656, 7, 86, N'Roda De Funk', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (657, 7, 96, N'Jota Quest-1995', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (659, 7, 99, N'Mais Do Mesmo', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (660, 8, 100, N'Greatest Hits', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (661, 8, 151, N'UB40 The Best Of - Volume Two [UK]', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (662, 8, 19, N'Acústico MTV [Live]', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (663, 8, 19, N'Cidade Negra - Hits', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (665, 9, 21, N'Axé Bahia 2001', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (666, 9, 252, N'Frank', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (667, 5, 276, N'Le Freak', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (668, 5, 278, N'MacArthur Park Suite', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
INSERT [dbo].[Album] ([AlbumId], [GenreId], [ArtistId], [Title], [Price], [AlbumArtUrl]) VALUES (669, 5, 277, N'Ring My Bell', CAST(8.99 AS Numeric(10, 2)), N'/Content/Images/placeholder.gif')
SET IDENTITY_INSERT [dbo].[Album] OFF
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[OrderDetail](
	[OrderDetailId] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [int] NOT NULL,
	[AlbumId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[UnitPrice] [numeric](10, 2) NOT NULL,
 CONSTRAINT [PK__InvoiceL__0D760AD91DE57479] PRIMARY KEY CLUSTERED 
(
	[OrderDetailId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

CREATE NONCLUSTERED INDEX [IFK_Invoice_InvoiceLine] ON [dbo].[OrderDetail] 
(
	[OrderId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]

CREATE NONCLUSTERED INDEX [IPK_InvoiceLine] ON [dbo].[OrderDetail] 
(
	[OrderDetailId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]

SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

SET ANSI_PADDING ON

CREATE TABLE [dbo].[Cart](
	[RecordId] [int] IDENTITY(1,1) NOT NULL,
	[CartId] [varchar](50) NOT NULL,
	[AlbumId] [int] NOT NULL,
	[Count] [int] NOT NULL,
	[DateCreated] [datetime] NOT NULL,
 CONSTRAINT [PK_Cart] PRIMARY KEY CLUSTERED 
(
	[RecordId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

SET ANSI_PADDING OFF

ALTER TABLE [dbo].[Album]  WITH CHECK ADD  CONSTRAINT [FK__Album__ArtistId__276EDEB3] FOREIGN KEY([ArtistId])
REFERENCES [dbo].[Artist] ([ArtistId])

ALTER TABLE [dbo].[Album] CHECK CONSTRAINT [FK__Album__ArtistId__276EDEB3]

ALTER TABLE [dbo].[Album]  WITH CHECK ADD  CONSTRAINT [FK_Album_Genre] FOREIGN KEY([GenreId])
REFERENCES [dbo].[Genre] ([GenreId])

ALTER TABLE [dbo].[Album] CHECK CONSTRAINT [FK_Album_Genre]

ALTER TABLE [dbo].[Cart]  WITH CHECK ADD  CONSTRAINT [FK_Cart_Album] FOREIGN KEY([AlbumId])
REFERENCES [dbo].[Album] ([AlbumId])

ALTER TABLE [dbo].[Cart] CHECK CONSTRAINT [FK_Cart_Album]

ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD  CONSTRAINT [FK__InvoiceLi__Invoi__2F10007B] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Order] ([OrderId])

ALTER TABLE [dbo].[OrderDetail] CHECK CONSTRAINT [FK__InvoiceLi__Invoi__2F10007B]

ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_InvoiceLine_Album] FOREIGN KEY([AlbumId])
REFERENCES [dbo].[Album] ([AlbumId])

ALTER TABLE [dbo].[OrderDetail] CHECK CONSTRAINT [FK_InvoiceLine_Album]

