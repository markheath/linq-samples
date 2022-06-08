<Query Kind="Expression">
  <Connection>
    <ID>5eb5d186-a779-490b-bfd9-ba9e62eca475</ID>
    <Server>(localdb)\v11.0</Server>
    <Database>SuaveMusicStore</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

// in a motor sport competition, a player's points total
// for the season is the sum of all the points earned in
// each race, but the three worst results are not counted
// towards the total. Calculate the following player's score
// based on the points earned in each round:
"10,5,0,8,10,1,4,0,10,1"
	.Split(',')
	.Select(s => int.Parse(s))
	.OrderBy(n => n)
	.Skip(3)
	.Sum()





























//	.Split(',')
//	//.Select(s => Int32.Parse(s))
//	.Select(int.Parse)
//	.OrderBy(n => n)
//	.Skip(3)
//	.Sum()
//	.Dump("Q1: Scores");
	
	
// pipeline stages
// select - transform
// where - filter
// composability
// readability