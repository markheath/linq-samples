<Query Kind="Statements">
  <NuGetReference>morelinq</NuGetReference>
  <Namespace>MoreLinq</Namespace>
</Query>

var testInput = new[] {
"Comet can fly 14 km/s for 10 seconds, but then must rest for 127 seconds." ,
"Dancer can fly 16 km/s for 11 seconds, but then must rest for 162 seconds." 
};
var realInput = File.ReadAllLines(Path.GetDirectoryName(Util.CurrentQueryPath) +
	"\\day14.txt");
var pattern = @"^(\w+) can fly (\d+) km/s for (\d+) seconds, but then must rest for (\d+)";
//can fly (\d+) .* for (\d+) *. for (\d+) seconds
var reindeer = realInput.Select(s =>
	Regex.Match(s,pattern)
	.Groups.Cast<Group>().Select(g => g.Value).ToArray())
	.Select(g => new { Name = g[1], Speed = int.Parse(g[2]), Duration = int.Parse(g[3]), Rest = int.Parse(g[4]) })
	.ToArray();

reindeer
	.Select(r => new
	{
		r.Name,
		Dist = Enumerable.Range(0, 2503).Sum(t => t % (r.Duration + r.Rest) < (r.Duration) ? r.Speed : 0)
	})
	.Dump()
	.MaxBy(r => r.Dist).Dist
	.Dump("a");