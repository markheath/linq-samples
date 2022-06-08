<Query Kind="Statements" />

var instructions = File.ReadAllLines(
	Path.GetDirectoryName(Util.CurrentQueryPath) +
	"\\day6.txt");

var pattern = @"(turn on|toggle|turn off)\ (\d+)\,(\d+)\ through\ (\d+)\,(\d+)";

var instructionsFlattened = instructions
	.Select(i => Regex.Match(i, pattern).Groups)
	.Select(g => new
	{
		Action = g[1].Value,
		From = new { 
			X = int.Parse(g[2].Value), 
			Y = int.Parse(g[3].Value) },
		To = new { 
			X = int.Parse(g[4].Value), 
			Y = int.Parse(g[5].Value) }
	})
	//.Dump()
	.SelectMany(i =>
		from x in Enumerable.Range(i.From.X, 1 + i.To.X - i.From.X)
		from y in Enumerable.Range(i.From.Y, 1 + i.To.Y - i.From.Y)
		select new { i.Action, x, y });

// apply the instructions
var lights = new bool[1000, 1000];
foreach (var i in instructionsFlattened)
{	
	if (i.Action == "turn on") 
		lights[i.x, i.y] = true;
	else if (i.Action == "turn off")
		lights[i.x, i.y] = false;
	else if (i.Action == "toggle")
		lights[i.x, i.y] = !lights[i.x, i.y];
}

// count the lights on
(from x in Enumerable.Range(0, 1000)
 from y in Enumerable.Range(0, 1000)
 where lights[x, y]
 select 1).Sum().Dump("lights on");