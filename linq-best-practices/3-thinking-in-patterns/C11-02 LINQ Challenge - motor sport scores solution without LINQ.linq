<Query Kind="Statements" />

// without LINQ
var scores = "10,5,0,8,10,1,4,0,10,1".Split(',');

var scoresAsInts = new List<int>();
foreach (var score in scores)
{
	var intScore = int.Parse(score);
	scoresAsInts.Add(intScore);
}

scoresAsInts.Sort();

var total = 0;
for (int n = 3; n < scoresAsInts.Count; n++)
{
	total += scoresAsInts[n];
}

total.Dump("Score without LINQ");