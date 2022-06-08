<Query Kind="Statements">
  <NuGetReference Prerelease="true">morelinq</NuGetReference>
  <Namespace>MoreLinq</Namespace>
</Query>

var testInput = @"London to Dublin = 464
London to Belfast = 518
Dublin to Belfast = 141".Split('\n');
var path = Path.GetDirectoryName(Util.CurrentQueryPath);
var realInput = File.ReadAllLines(Path.Combine(path, "day9.txt"));

var distances = realInput	
	.Select(s => Regex.Match(s, @"^(\w+) to (\w+) = (\d+)").Groups)
	.Select(g => new { From = g[1].Value, To = g[2].Value, Distance = int.Parse(g[3].Value) })
	.ToList();
	
var places = distances.SelectMany(d => new[] { d.From, d.To }).Distinct().ToList();

Func<string,string,int> getDistance = (a,b) => distances
	.FirstOrDefault(d => (d.From == a && d.To == b) || 
							(d.To == a && d.From == b)).Distance;
//places.Dump();	
//places.Permutations().Dump();

// brute force it
var routeLengths = places.Permutations()
	.Select(route => route.Pairwise((from, to) => getDistance(from, to)).Sum());

routeLengths.Min().Dump("a"); // 207
routeLengths.Max().Dump("b"); // 804