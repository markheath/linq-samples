<Query Kind="Statements">
  <NuGetReference>morelinq</NuGetReference>
  <Namespace>MoreLinq</Namespace>
</Query>

Directory.SetCurrentDirectory(Path.GetDirectoryName(Util.CurrentQueryPath));
var lookup = File.ReadAllLines("day14.txt").Select(s => s.Split(' '))
	.Select(g => new { Speed = int.Parse(g[3]), Duration = int.Parse(g[6]), Rest = int.Parse(g[13]) })
	.Select(r => 
		Enumerable.Range(0, 2503)
		.Select(t => t % (r.Duration + r.Rest) < r.Duration ? r.Speed : 0)
		.Scan(0, (a, b) => a + b).Skip(1).ToArray())
	.ToArray();
lookup.Max(v => v[v.Length-1]).Dump("a"); // 2640
lookup.Max(v => v.Select((n,t) => n == lookup.Max(q => q[t]) ? 1 : 0).Sum()).Dump("b"); // 1102