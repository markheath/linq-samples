<Query Kind="Statements" />

var instructions = File.ReadAllLines(
	Path.GetDirectoryName(Util.CurrentQueryPath) +
	"\\day6.txt");

var lights = new int[1000, 1000];

var pattern = @"(turn on|toggle|turn off)\ (\d+)\,(\d+)\ through\ (\d+)\,(\d+)";
var match = Regex.Match("turn on 0,0 through 999,999", pattern)
	.Groups.Cast<Group>()
	.Select(g => g.Value);

var instructionsFlattened =
instructions
	.Select(i => Regex.Match(i, pattern).Groups)
	.Select(g => new
	{
		Instruction = g[1].Value,
		From = Tuple.Create(int.Parse(g[2].Value), int.Parse(g[3].Value)),
		To = Tuple.Create(int.Parse(g[4].Value), int.Parse(g[5].Value))
	})
	.Dump()
	.SelectMany(i =>
		from x in Enumerable.Range(i.From.Item1, 1 + i.To.Item1 - i.From.Item1)
		from y in Enumerable.Range(i.From.Item2, 1 + i.To.Item2 - i.From.Item2)
		select new { i.Instruction, Position = Tuple.Create(x, y) });

// apply the instructions
foreach (var i in instructionsFlattened)
{
	var x = i.Position.Item1;
	var y = i.Position.Item2;
	var brightness = lights[x,y];
	if (i.Instruction == "turn on") lights[x, y] = brightness+1;
	else if (i.Instruction == "turn off") lights[x, y] = Math.Max(0, brightness - 1);
	else if (i.Instruction == "toggle") lights[x, y] = brightness += 2;
}

(from x in Enumerable.Range(0, 1000)
from y in Enumerable.Range(0, 1000)
	select lights[x,y]).Sum().Dump("brightness"); // 14687245