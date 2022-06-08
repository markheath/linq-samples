<Query Kind="Statements" />

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
	.Dump("Score");

// without LINQ
var scores = "10,5,0,8,10,1,4,0,10,1".Split(',');
var scoresAsInts = new List<int>();
foreach (var score in scores)
{
	var intScore= int.Parse(score);
	scoresAsInts.Add(intScore);
}
scoresAsInts.Sort();
var total = 0;
for (int n = 3; n < scoresAsInts.Count; n++)
{
	total += scoresAsInts[n];
}
total.Dump("Score without LINQ");