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

Enumerable.Range(0, 2503)
	.Select(t =>
		reindeer.Select(r =>
			new
			{
				r.Name,
				Dist = t % (r.Duration + r.Rest) < (r.Duration) ? r.Speed : 0,
			}).ToArray())
	.Scan(reindeer.Select(r => new
	{
		r.Name,
		Cumulative = 0
	}).ToArray(), (acc, n) => Enumerable.Zip(acc, n, (a, b) => new
	{
		a.Name,
		Cumulative = a.Cumulative + b.Dist
	}).ToArray())
	.Skip(1)
	.SelectMany(d => d.OrderByDescending(e => e.Cumulative)
				.GroupAdjacent(e => e.Cumulative)
				.First()
				.Select(g => g.Name))
	.GroupBy(n => n)
	.Select(g => new { Name = g.Key, Points = g.Count() })
	.Dump()
	.MaxBy(g => g.Points).Points.Dump("b");
			